using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance
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
    [SerializeField]
    private int playerHpSetting = 3;
    private int playerHp;
    //[SerializeField]
    //private int bossHpSetting = 10;
    //private int bossHp;
    [SerializeField]
    //private int gruntCountSetting = 10;
    //private int gruntCount;
    private bool gruntClear = false;

    public TextMeshProUGUI questionText;
    public GameObject answerButtonPrefab;
    public Transform answerButtonParent;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    private bool isRoundActive;
    private int timer;
    private int questionIndex;

    public void StartGame()
    {
        Debug.Log("Start game");
        playerHp = playerHpSetting;
        //bossHp = bossHpSetting; 
        //gruntCount = gruntCountSetting;
        gruntClear = false;
        GruntControl.Instance.StartGrunts();

        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;

        timer = 0;
        InvokeRepeating("Timer", 0f, 1f);
        questionIndex = 0;
        isRoundActive = true;

        ShowQuestion();
    }
    public void EndGame()
    {
        Debug.Log("End game");
        GruntControl.Instance.ResetGrunts();
        if (gruntClear)
        {
            //BossControl.Instance.ResetBoss();
            Debug.Log("Win");
        }

        CancelInvoke("Timer");
        SessionControl.Instance.GoToSession("Title");
    }
    private void Timer()
    {
        timer++;
    }
    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionText.SetText(questionData.questionText);
        for (int i = 0; i<questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = Instantiate(answerButtonPrefab);
            answerButtonGameObject.transform.SetParent(answerButtonParent, false);
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.GetComponent<AnswerButton>().Setup(questionData.answers[i]);
        }
    }
    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            Destroy(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }
    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            Debug.Log("Correct answer");
            //gruntCount--;
            //if (gruntCount <= 0)
            if (questionIndex + 1 >= questionPool.Length)
            {
                Debug.Log("Grunt cleared");
                gruntClear = true;
                GruntControl.Instance.ResetGrunts();
                EndGame();
            }
            else
            {
                GruntControl.Instance.CycleGrunts();
                questionIndex++;
                ShowQuestion();
            }
        }
        else
        {
            Debug.Log("Wrong answer");
            playerHp--;
            if (playerHp <= 0)
            {
                Debug.Log("No more HP");
                EndGame();
            }
        }
    }
}
