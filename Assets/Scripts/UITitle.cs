using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitle : UITemplate
{
    public GameObject introPanel;
    public GameObject stageSelectPanel;
    int stageIndex = 0;


    private void Start()
    {
        introPanel.SetActive(true);
    }
    public void StageSelectPanel(int stageIndex)
    {
        stageSelectPanel.SetActive(true);
        stageSelectPanel.GetComponent<UIPanelStageSelect>().SetStageIndex(stageIndex);

        //change panel content
    }
    public void Options()
    {
        SessionControl.Instance.GoToSession("Options");
    }
    public void Achievement()
    {
        SessionControl.Instance.GoToSession("Achievement");
    }
}
