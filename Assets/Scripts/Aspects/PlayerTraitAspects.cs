using Move;
using System.Collections;
using System.Collections.Generic;
using TraitComponents;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using Unity.VisualScripting;
using UnityEngine;

readonly partial struct PlayerTraitAspect : IAspect
{
    
    readonly RefRW<PickedTraitDic> pickedTraitDic;
    readonly RefRW<PickableTraitDic> pickableTraitDic;
    readonly RefRW<PickedSocket> pickedSocket;
    readonly RefRW<RandomCount> randomCount;


    public void AddPickedTrait(TraitType traitType,int id,TraitRarityType traitRarityType,int level=1)
    {
        int type = id / 10000;
        bool flag = false;
        PickedTraitData t = new PickedTraitData();
        t.traitID = id;
        //t.socketType = Datas.TraitDic[traitType][id].socketType;
        t.rarity = (int)traitRarityType;
        t.level = level;
        if (t.traitID % 10 != 4) pickedSocket.ValueRW.value.Add(t.traitID % 10);

        foreach(var item in pickedTraitDic.ValueRW.value)
        {
            if (item.type == type)
            {
                item.value.Add(t);
                flag = true;
                break;
            }
        }
        if (!flag)
        {
            PickedTrait t1 = new PickedTrait();
            t1.type = type;
            t1.value = new NativeList<PickedTraitData>();
            t1.value.Add(t);
        }
        AddPickedableTrait(traitType,id);
    }

    public void RemovePickedTrait(int id)
    {
        for(int i = 0; i < pickedTraitDic.ValueRO.value.Length;i++)
        {
            for(int j=0;j< pickedTraitDic.ValueRO.value[i].value.Length;j++)
            {
                pickedTraitDic.ValueRW.value[i].value.RemoveAt(j);
                break;
            }
        }
    }

    public NativeList<PickedTrait> GetAllPickedTrait()
    {
        return pickedTraitDic.ValueRO.value;
    }

    public void AddPickedableTrait(TraitType traitType,int id)
    {
        PickableTraitData t = new PickableTraitData();
        t.traitID = id;
        t.probability = Datas.TraitDic[traitType][id].probability;
        t.preTrait1 = Datas.TraitDic[traitType][id].preTrait1.ToNativeList<int>(Allocator.Persistent);
        t.preTrait2 = Datas.TraitDic[traitType][id].preTrait2.ToNativeList<int>(Allocator.Persistent);

        //pickableTraitDic.ValueRW.value.Add(t);
    }
    public void RemovePickableTrait(int id)
    {
        /*for (int i = 0; i < pickableTraitDic.ValueRO.value.Length; i++)
        {
            if (pickableTraitDic.ValueRO.value[i].traitID == id)
            {
                pickableTraitDic.ValueRW.value.RemoveAt(i);
                break;
            }
        }*/
    }
    public NativeList<PickableTrait> GetAllPickableTrait()
    {
        return pickableTraitDic.ValueRO.value;
    }
    public NativeList<PickableTraitData> GetPickableTrait(int type)
    {
        foreach(var item in pickableTraitDic.ValueRO.value)
        {
            if (item.type == type) return item.value;
        }
        return default;
    }

    public NativeList<int> GetAllPickableSocket()
    {
        return pickedSocket.ValueRO.value;
    }

    public void CalcRandomCount()
    {
        randomCount.ValueRW.value = 0;
        foreach(var t in pickableTraitDic.ValueRO.value)
        {
            foreach (var item in t.value)
            {
                foreach (var T in Datas.TraitDic)
                {
                    if (T.Value.ContainsKey(item.traitID)) randomCount.ValueRW.value += T.Value[item.traitID].probability;
                }
            }
        }       
    }
    public float GetRandomCount()
    {
        return randomCount.ValueRO.value;
    }
}

