using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelGeneric : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;
    public virtual void ReturnToTitle()
    {
        SessionControl.Instance.GoToSession("Title");
    }
    public virtual void ClosePanel()
    {
        ButtonBehavior();
        gameObject.SetActive(false);
    }
    public virtual void ButtonBehavior()
    {
        AudioPlayer.Instance.PlaySfx(AudioPlayer.Instance.buttonSfx);
        Debug.Log("Click: " + gameObject.name);
    }
}
