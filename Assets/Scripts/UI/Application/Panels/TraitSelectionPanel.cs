using System;
using System.Collections;
using System.Collections.Generic;
using TraitComponents;
using UIFrameWork;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;
//using static UnityEngine.Rendering.DebugUI;

public class TraitSelectionPanel : BasePanel
{
    private static readonly string path = "Prefabs/Panels/TraitSelectionPanel";

    private PickedTraitData[] pickedTraitDatas;

    public TraitSelectionPanel(PickedTraitData[] t) : base(new UIType(path))
    {
        pickedTraitDatas = t;
    }
    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);

        UITool.GetOrAddComponentInChildren<Button>("Btn_Exit", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Pop();
        });
        for (int i = 1; i <= 3; i++)
        {
            AddOptionData(i, panel);
        }
    }

    private void AddOptionData(int index,GameObject panel)
    {
        index -= 1;
        var data = Datas.TraitDic[(TraitType)Enum.Parse(typeof(TraitType), (pickedTraitDatas[index].traitID / 10000).ToString())][pickedTraitDatas[index].traitID];
        
        GameObject option = UITool.GetOrAddComponentInChildren<Transform>("Option" + (index+1), panel).gameObject;
        UITool.GetOrAddComponentInChildren<Button>("Btn_Option", option).onClick.AddListener(() =>
        {
            Debug.Log("获得ID为："+ data.traitID+"的祝福.");
            PanelManager.Instance.Pop();

        });
        UITool.GetOrAddComponentInChildren<Text>("Text_Describe", option).text =data.describe+"稀有度为+"+pickedTraitDatas[index].rarity;
    }
}
