using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TraitComponents
{
    //区分祝福属于哪个神系的枚举类
    public enum TraitType
    {
        Default,
        Zeus=1,
        Athena=2
    }

    //区分祝福属于哪个类型槽位的枚举类
    public enum TraitSocketType
    {
        Default,
        NormalAttack=1,
        SpecialAttack=2,
        Bombing=3
    }
    public enum TraitRarityType
    {
        Common=1,
        Rare=2,
        Epic=3
    }

    public struct TraitData
    {
        public int traitID;
        public string traitName;
        //public int socketType;
        public float probability;
        public List<int> rarityTypes;
        public float rate;
        public string describe;
        public List<int> preTrait1;
        public List<int> preTrait2;
    }

    public struct PickedTraitData
    {
        public int traitID;
        //public int socketType;
        public int rarity;
        public int level;       
    }
    public struct PickableTraitData
    {
        public int traitID;
        public float probability;
        //public int socketType;
        public NativeList<int> preTrait1;
        public NativeList<int> preTrait2;
    }

    struct TraitDataTag : IComponentData { }

    struct RandomCount : IComponentData
    {
        public float value;
    }
    struct PickedTrait
    {
        public int type;
        //public NativeHashMap<int, PickedTraitData> value;
        public NativeList<PickedTraitData> value;
    }
    [ChunkSerializable]
    struct PickedTraitDic : IComponentData
    {       
        public NativeList<PickedTrait> value;
    }
    struct PickableTrait
    {
        //public NativeHashMap<int, PickableTraitData> value;
        public int type;
        public NativeList<PickableTraitData> value;
    }
    [ChunkSerializable]
    struct PickableTraitDic : IComponentData
    {
        public NativeList<PickableTrait> value;
    }

    [ChunkSerializable]
    struct PickedSocket : IComponentData
    {
        public NativeList<int> value;
    }

    struct RandomTrait:IComponentData 
    {
        
    }

    struct TraitTypeTag : IComponentData
    {
        public TraitType value;
    }   
}

