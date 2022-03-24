using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionAnswerLogic : MonoBehaviour
{
    private static QuestionAnswerLogic instance;
    public static QuestionAnswerLogic Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public string question = "Q";
    public string correctAnswer = "A";
    public List<string> answers = new List<string> { "A", "X", "Y", "Z" };

    [SerializeField]
    GameObject[] answerButtons;

    public void NewQuestion()
    {
        question = "Q";
        correctAnswer = "A";
        answers = new List<string> { "A", "X", "Y", "Z" };
        Populate();
    }
    public void Populate()
    {
        ShuffleAnswers();
        for (int i = 0; i<answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().SetText(answers[i]);

            if (answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text.Equals(correctAnswer))
            {
                answerButtons[i].GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                answerButtons[i].GetComponentInChildren<Button>().onClick.AddListener(UIGame.Instance.GoodAnswer);
            }
            else
            {
                answerButtons[i].GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                answerButtons[i].GetComponentInChildren<Button>().onClick.AddListener(UIGame.Instance.BadAnswer);
            }
        }
    }
    private void ShuffleAnswers()
    {
        for (int i = 0; i<answers.Count; i++)
        {
            string temp = answers[i];
            int rand = Random.Range(i, answers.Count);
            answers[i] = answers[rand];
            answers[rand] = temp;
        }
    }
}
