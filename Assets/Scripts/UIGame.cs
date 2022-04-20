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

    public override void ReturnToTitle()
    {
        GameController.Instance.EndGame(true);
        base.ReturnToTitle();
    }
}
