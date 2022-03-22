using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitle : UITemplate
{
    public void StartGame()
    {
        SessionControl.Instance.goToSession("Game");
    }
    public void Options()
    {
        SessionControl.Instance.goToSession("Settings");
    }
}
