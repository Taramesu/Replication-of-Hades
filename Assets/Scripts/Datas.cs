using System.Collections;
using System.Collections.Generic;
using TraitComponents;
using UnityEngine;

public static class Datas
{
    public static Dictionary<TraitType, List<TraitData>> TraitDic=new Dictionary<TraitType, List<TraitData>>();

    //玩家已有的祝福，ID和具体信息（比如稀有度、等级、所属插槽），ID做键是方便查找
    public static Dictionary<int, ExistingTraitData> ExistingTrait = new Dictionary<int, ExistingTraitData>();

    //可随机出的技能池,ID和出现几率
    public static Dictionary<int,float> RandomizableTrait = new Dictionary<int,float>();

    //按插槽查找祝福
    public static Dictionary<int, List<int>> SocketTrait = new Dictionary<int, List<int>>();
}
