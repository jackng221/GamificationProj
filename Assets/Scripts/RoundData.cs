using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoundData
{
    public string name;
    [TextArea]
    public string intro;
    public QuestionData[] questions;
}
