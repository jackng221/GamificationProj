using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGamePanel : UITemplate
{
    public virtual void ConfirmEndGame()
    {
        gameObject.SetActive(false);
        GameController.Instance.ClearGameStatus();
        ReturnToTitle();
    }
    public virtual void ConfirmResume()
    {
        gameObject.SetActive(false);
        GameController.Instance.ResumeRound();
    }
}
