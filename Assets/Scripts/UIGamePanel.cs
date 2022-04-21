using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGamePanel : UITemplate
{
    public void ConfirmEndGame()
    {
        gameObject.SetActive(false);
        GameController.Instance.ClearGameStatus();
        ReturnToTitle();
    }
    public void ConfirmResume()
    {
        gameObject.SetActive(false);
        GameController.Instance.ResumeRound();
    }
}
