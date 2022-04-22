using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptions : UITemplate
{
    public void SaveProgress()
    {
        ProgressController.Instance.SaveProgress();
    }
    public void ClearProgress()
    {
        ProgressController.Instance.ClearProgress();
    }
}
