using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPanelGame : UIPanel
{
    public virtual void ConfirmEndGame()
    {
        gameObject.SetActive(false);
        GameController.Instance.ClearGameStatus();
        ReturnToTitle();
    }
    public virtual void ConfirmResumeGame()
    {
        gameObject.SetActive(false);
        GameController.Instance.ResumeRound();
    }
}
