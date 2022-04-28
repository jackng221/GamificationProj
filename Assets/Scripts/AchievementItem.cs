using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    public GameObject textObj;
    public GameObject imgObj;

    public void SetAttribute(string text, Sprite sprite)
    {
        textObj.GetComponent<TextMeshProUGUI>().SetText(text);
        imgObj.GetComponent<Image>().sprite = sprite;
    }
}
