using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TraitComponents;
using Unity.Burst;
using Unity.Jobs;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Collections;
using player;
using UnityEditor.Experimental.GraphView;

[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
[UpdateAfter(typeof(InitializationSystemGroup))]
public partial class RandomTraitSystem : SystemBase
{
    bool isFinish;
    HashSet<int> randomList;
    List<PickedTraitData> res;

    protected override void OnCreate()
    {
        isFinish = false;
        randomList = new HashSet<int>() {10011,10022 };
        res = new List<PickedTraitData>();
    }

    protected override void OnUpdate()
    {
        //var ecbBOS = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

        /*Entities
            .WithAll<TraitTypeTag, RandomTrait>()
            .ForEach
            ((Entity entity, in TraitTypeTag traitTypeTag, in RandomTrait isRandomTrait) =>
        {
            //RandomTrait(traitTypeTag);
            //entityCommandBuffer.DestroyEntity(entityInQueryIndex,entity);
        }).Schedule();*/

        foreach (var traitTypeTag in SystemAPI.Query<RefRO<TraitTypeTag>>().WithAll<RandomTrait>())
        {
            RandomTrait(traitTypeTag);
        }
        //Debug.Log(Datas.TraitDic.Count);
        //jobHandle.Complete();

        /*for (int i = 0; i < traitEntities.Length; i++)
        {
            EntityManager.DestroyEntity(traitEntities[i]);
        }*/
        if (isFinish)
        {
            EntityQuery entitys = this.GetEntityQuery(typeof(RandomTrait));
            EntityManager.DestroyEntity(entitys);
            Debug.Log("共抽取"+res.Count+"个祝福");
            foreach(var item in res)
            {
                Debug.Log("ID:" + item.traitID);
                Debug.Log("稀有度" + item.rarity);
            }
            isFinish = false;
        }
    }

    private void RandomTrait(RefRO<TraitTypeTag> traitTypeTag)
    {
        foreach (var playerTraitAspect in SystemAPI.Query<PlayerTraitAspect>().WithAll<PlayerTag>())
        {
            Dictionary<int, TraitData> dic = Datas.TraitDic[traitTypeTag.ValueRO.value];
            var pickedTrait = playerTraitAspect.GetAllPickedTrait();

            //如果玩家还没有任何特殊插槽的祝福，则优先生成三个特殊插槽的祝福(第一次一般一定走这里）
            if (playerTraitAspect.GetAllPickableSocket().Length <= 0)
            {
                foreach (var item in dic)
                {
                    if (item.Value.traitID%10 != 4 && randomList.Count < 3) randomList.Add(item.Key);
                }
            }
            //如果玩家已经有了特殊插槽的祝福并且该祝福不属于当前神系，有10%的几率重新获得特殊插槽祝福
            else if(Random.Range(0, 100) < 10)
            {
                /*foreach (var item in pickedTrait)
                {
                    foreach(var t in item.value)
                    {
                        if (t.traitID / 10000 != (int)traitTypeTag.ValueRO.value)
                        {
                            foreach (var temp in dic)
                            {
                                if (temp.Key % 10 == t.traitID % 10) { randomList.Add(temp.Key); break; }
                            }
                        }
                    }                   
                }*/
            }
            
            //经过上面几步后如果还不满三个，就从所有当前神系的可选祝福中按概率随机抽取
            if (randomList.Count < 3)
            {
                int randomNum = 3-randomList.Count;
                while(--randomNum >= 0)
                {
                    int t = ExtractTrait(randomList,
                    playerTraitAspect.GetPickableTrait((int)traitTypeTag.ValueRO.value),
                    playerTraitAspect.GetRandomCount());
                    if(t!=-1) randomList.Add(t);
                }
            }
            //如果还不满三个，则直接抽取直到满三个，不再随机
            if (randomList.Count < 3)
            {
                var list = playerTraitAspect.GetPickableTrait((int)traitTypeTag.ValueRO.value);
                int randomNum= 3 - randomList.Count;
                while (--randomNum >= 0)
                {
                    int t = Random.Range(0, list.Length);
                    randomList.Add(list[t].traitID);
                }
            }
            foreach(var item in randomList)
            {
                PickedTraitData ptd = new PickedTraitData();
                ptd.traitID = item;

                int t = Random.Range(0, 100);
                if (t < 20 && dic[item].rarityTypes.Contains(4)) ptd.rarity = 4;
                else if (t < 35 && dic[item].rarityTypes.Contains(3)) ptd.rarity = 3;
                else if (t < 50 && dic[item].rarityTypes.Contains(2)) ptd.rarity = 2;
                else ptd.rarity = 1;

                ptd.level = 1;
                res.Add(ptd);
            }   
            
            isFinish = true;
        }
        //var sockets = playerTraitAspect.GetAllPickableSocket();        
    }
    private int ExtractTrait(HashSet<int> indices,NativeList<PickableTraitData> pickableTrait,float randomCount)
    {
        int id = -1;

        float t_random = Random.Range(0, randomCount * 100);
        foreach (var item in pickableTrait)
        {
            if (t_random < item.probability * 100)
            {
                if (!indices.Contains(item.traitID))
                {
                    id = item.traitID;
                    break;
                }
            }
            t_random -= item.probability * 100;
        }

        return id;
    }
}
