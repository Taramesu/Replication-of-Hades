using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using Unity.Entities;
using TraitComponents;
using System;
using Unity.Burst;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
public partial class ReadTraitDataSystem : SystemBase
{
    protected override void OnCreate()
    {
        string jsonString = Resources.Load<TextAsset>("Data/Trait").text;

        //Dictionary<TraitType, List<TraitData>> traitDic = new Dictionary<TraitType, List<TraitData>>();

        JsonData jsonData = JsonMapper.ToObject(jsonString);
        foreach (JsonData traitDataJson in jsonData)
        {
            TraitData traitData = new TraitData();            
            traitData.traitID = ((int)traitDataJson["TraitID"]);
            var traitType = (TraitType)Enum.Parse(typeof(TraitType), (traitData.traitID/100).ToString());
            traitData.socketType = (int)traitDataJson["TraitSocketType"];
            traitData.probability= float.Parse(traitDataJson["Probability"].ToString());
            traitData.rarityTypes = new List<int>();
            foreach (JsonData item in traitDataJson["TraitRarities"])
            {
                traitData.rarityTypes.Add((int)item);
            }
            traitData.rate = float.Parse(traitDataJson["Rate"].ToString());
            traitData.describe = traitDataJson["Describe"].ToString();
            traitData.preTrait1 = new List<int>();
            foreach(JsonData item in traitDataJson["PreTrait1"])
            {
                traitData.preTrait1.Add((int)item);
            }
            traitData.preTrait2 = new List<int>();
            foreach (JsonData item in traitDataJson["PreTrait2"])
            {
                traitData.preTrait2.Add((int)item);
            }

            if (!Datas.TraitDic.ContainsKey(traitType)) Datas.TraitDic.Add(traitType, new List<TraitData>());
            Datas.TraitDic[traitType].Add(traitData);
            if (!Datas.SocketTrait.ContainsKey(traitData.socketType)) Datas.SocketTrait.Add(traitData.socketType, new List<int>());
            Datas.SocketTrait[traitData.socketType].Add(traitData.traitID);
            if (traitData.preTrait1.Count <= 0 && traitData.preTrait2.Count <= 0) Datas.RandomizableTrait.Add(traitData.traitID, traitData.probability);
        }

        /*Entity entity =  EntityManager.CreateEntity();
        //建立一个空物体挂载数据
        EntityManager.AddComponent(entity, typeof(TraitDataTag));
        EntityManager.AddComponent(entity, typeof(TraitDataDic));*/
    }

    protected override void OnUpdate()
    {
        
    }
}
