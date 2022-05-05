using System.Collections;
using UnityEngine;

[System.Serializable]
public class Progress
{
    public enum Names
    {
        perfectClearWeather,
        perfectClearFoodSafety,
        Right10,
        Right20,
        Right40,
        Wrong5,
        Wrong10,
        Wrong20

    }
    public Sprite sprite;
    public Names progressEnum;
    public int isAchieved = 0;
    [TextArea]
    public string text;
    [TextArea]
    public string dateText;
}
