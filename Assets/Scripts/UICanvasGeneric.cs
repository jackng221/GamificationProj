using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasGeneric : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;
    public virtual void ReturnToTitle()
    {
        ButtonBehavior();
        SessionControl.Instance.GoToSession("Title");
    }
    public virtual void ButtonBehavior()
    {
        AudioPlayer.Instance.PlaySfx(AudioPlayer.Instance.buttonSfx);
    }
}
