using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGame : UITemplate
{
    private static UIGame instance;
    public static UIGame Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

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
