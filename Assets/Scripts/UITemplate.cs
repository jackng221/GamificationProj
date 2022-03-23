using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class UITemplate : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;
    public virtual void Back()
    {
        SessionControl.Instance.GoToSession("Title");
    }
}
