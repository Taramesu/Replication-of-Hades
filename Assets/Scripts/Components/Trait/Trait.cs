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
        public int socketType;
        public float probability;
        public List<int> rarityTypes;
        public float rate;
        public string describe;
        public List<int> preTrait1;
        public List<int> preTrait2;
    }

    public struct ExistingTraitData
    {
        public int rarity;
        public int level;
        public int socketType;
    }

    struct TraitDataTag : IComponentData { }

    struct IsRandomTrait:IComponentData 
    {
        public bool value;
    }

    struct TraitTypeTag : IComponentData
    {
        public TraitType traitType;
    }   
}

