using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData
{
    public string questionText;
    public string consequenceText;
    public string explanationText;
    public AnswerData[] answers;

    public string graphic;
}
