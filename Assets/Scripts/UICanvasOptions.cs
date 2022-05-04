using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasOptions : UICanvasGeneric
{
    public void ClearProgress()
    {
        ButtonBehavior();
        ProgressController.Instance.ClearProgress();
    }
}
