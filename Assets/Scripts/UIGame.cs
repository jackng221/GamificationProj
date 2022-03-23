using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGame : UITemplate
{
    public void GoodAnswer()
    {
        GameplayManager.Instance.Answer(true);
    }
    public void BadAnswer()
    {
        GameplayManager.Instance.Answer(false);
    }
    public override void Back()
    {
        GameplayManager.Instance.EndGame();
        base.Back();
    }
}
