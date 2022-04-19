using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class UITemplate : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;
    public virtual void ReturnToTitle()
    {
        SessionControl.Instance.GoToSession("Title");
    }
}
