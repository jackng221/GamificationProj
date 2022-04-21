using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : UITemplate
{
    public virtual void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
