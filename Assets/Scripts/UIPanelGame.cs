using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPanelGame : UIPanelGeneric
{
    public virtual void ConfirmEndGame()
    {
        ButtonBehavior();
        gameObject.SetActive(false);
        GameController.Instance.ClearGameStatus();
        ReturnToTitle();
        AudioPlayer.Instance.SwitchBgm(AudioPlayer.Instance.titleBgm);
    }
    public virtual void ConfirmResumeGame()
    {
        ButtonBehavior();
        gameObject.SetActive(false);
        GameController.Instance.ResumeRound();
    }
}
