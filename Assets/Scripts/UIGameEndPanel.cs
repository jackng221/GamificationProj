using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameEndPanel : UITemplate
{
    public void Confirm()
    {
        gameObject.SetActive(false);
        GameController.Instance.ClearGameStatus();
        ReturnToTitle();
    }
}
