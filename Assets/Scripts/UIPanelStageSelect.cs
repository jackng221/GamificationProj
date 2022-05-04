using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelStageSelect : UIPanelGeneric
{
    private int stageIndex = 0;
    private RoundData roundData;

    public void SetStage(int stageIndex)
    {
        this.stageIndex = stageIndex;
        roundData = DataController.Instance.GetRoundData(stageIndex);
        GetComponentInChildren<TextMeshProUGUI>().SetText(roundData.intro);
        StartCoroutine("RefreshLayout");
    }
    public void ConfirmStageSelect()
    {
        ButtonBehavior();
        gameObject.SetActive(false);
        SessionControl.Instance.GoToSession("Game");
        GameController.Instance.StartGame(stageIndex);
    }
    IEnumerator RefreshLayout()
    {
        yield return new WaitForSeconds(0.0001f);
        GetComponent<VerticalLayoutGroup>().enabled = false;
        GetComponent<VerticalLayoutGroup>().enabled = true;
    }
}
