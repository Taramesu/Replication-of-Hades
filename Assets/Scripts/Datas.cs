using System.Collections;
using System.Collections.Generic;
using TraitComponents;
using UnityEngine;

public static class Datas
{
    public static Dictionary<TraitType, List<TraitData>> TraitDic=new Dictionary<TraitType, List<TraitData>>();

    //������е�ף����ID�;�����Ϣ������ϡ�жȡ��ȼ���������ۣ���ID�����Ƿ������
    public static Dictionary<int, ExistingTraitData> ExistingTrait = new Dictionary<int, ExistingTraitData>();

    //��������ļ��ܳ�,ID�ͳ��ּ���
    public static Dictionary<int,float> RandomizableTrait = new Dictionary<int,float>();

    //����۲���ף��
    public static Dictionary<int, List<int>> SocketTrait = new Dictionary<int, List<int>>();
}
