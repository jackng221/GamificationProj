using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelStageSelect : UIPanel
{
    public int stageIndex = 0;
    public void SetStageIndex(int stageIndex)
    {
        this.stageIndex = stageIndex;
    }
    public void ConfirmStageSelect()
    {
        gameObject.SetActive(false);
        SessionControl.Instance.GoToSession("Game");
        GameController.Instance.StartGame(stageIndex);
    }
}
