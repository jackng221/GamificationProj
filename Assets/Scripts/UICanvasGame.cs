using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasGame : UICanvasGeneric
{
    public override void ReturnToTitle()
    {
        GameController.Instance.EndGame(true);
        base.ReturnToTitle();
        AudioPlayer.Instance.SwitchBgm(AudioPlayer.Instance.titleBgm);
    }
}
