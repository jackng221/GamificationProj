using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitle : UITemplate
{
    public void StartGame()
    {
        SessionControl.Instance.GoToSession("Game");
    }
    public void Options()
    {
        SessionControl.Instance.GoToSession("Options");
    }
    public void Achievement()
    {
        SessionControl.Instance.GoToSession("Achievement");
    }
}
