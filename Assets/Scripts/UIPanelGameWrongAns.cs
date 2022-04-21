using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelGameWrongAns : UIPanelGame
{
    public override void ConfirmResumeGame()
    {
        GameController.Instance.WrongAnsReturn();
        base.ConfirmResumeGame();
    }
    private void OnEnable()
    {
        QuestionData question = GameController.Instance.GetQuestionPool()[GameController.Instance.GetQuestionIndex()];
        GetComponentInChildren<TextMeshProUGUI>().SetText(question.consequenceText + "\n\n" + question.explanationText);
        StartCoroutine("test");
    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(0.0001f);
        RefreshLayout();
    }
    private void RefreshLayout()
    {
        GetComponent<VerticalLayoutGroup>().enabled = false;
        GetComponent<VerticalLayoutGroup>().enabled = true;
    }
}
