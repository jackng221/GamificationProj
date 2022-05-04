using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAnswerButton : MonoBehaviour
{
    public TextMeshProUGUI answerText;

    private AnswerData answerData;
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }
    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.SetText(answerData.answerText);
    }
    public void HandleClick()
    {
        AudioPlayer.Instance.PlaySfx(AudioPlayer.Instance.buttonSfx);
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}
