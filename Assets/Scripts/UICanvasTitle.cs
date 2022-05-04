using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasTitle : UICanvasGeneric
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
        ButtonBehavior();
        stageSelectPanel.SetActive(true);
        stageSelectPanel.GetComponent<UIPanelStageSelect>().SetStage(stageIndex);

        //change panel content
    }
    public void Options()
    {
        ButtonBehavior();
        SessionControl.Instance.GoToSession("Options");
    }
    public void Achievement()
    {
        ButtonBehavior();
        SessionControl.Instance.GoToSession("Achievement");
    }
}
