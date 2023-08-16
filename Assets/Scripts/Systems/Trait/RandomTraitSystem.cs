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
            Debug.Log("����ȡ"+res.Count+"��ף��");
            foreach(var item in res)
            {
                Debug.Log("ID:" + item.traitID);
                Debug.Log("ϡ�ж�" + item.rarity);
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

            //�����һ�û���κ������۵�ף�����������������������۵�ף��(��һ��һ��һ�������
            if (playerTraitAspect.GetAllPickableSocket().Length <= 0)
            {
                foreach (var item in dic)
                {
                    if (item.Value.traitID%10 != 4 && randomList.Count < 3) randomList.Add(item.Key);
                }
            }
            //�������Ѿ����������۵�ף�����Ҹ�ף�������ڵ�ǰ��ϵ����10%�ļ������»��������ף��
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
            
            //�������漸��������������������ʹ����е�ǰ��ϵ�Ŀ�ѡף���а����������ȡ
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
            //�����������������ֱ�ӳ�ȡֱ�����������������
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
