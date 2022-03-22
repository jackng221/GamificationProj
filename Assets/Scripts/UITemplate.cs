using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITemplate : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;
    public void Back()
    {
        SessionControl.Instance.GoToSession("Title");
    }
}
