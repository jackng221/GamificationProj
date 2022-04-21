﻿using System.Collections;
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
    public GameObject playerObj;
    [SerializeField]
    private int playerHpSetting = 3;
    private int playerHp;
    //[SerializeField]
    //private int bossHpSetting = 10;
    //private int bossHp;
    [SerializeField]
    //private int gruntCountSetting = 10;
    //private int gruntCount;
    private bool stageCleared = false;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI timerText;
    public GameObject answerButtonPrefab;
    public Transform answerButtonParent;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    private bool isRoundActive;
    private int timer;
    private int questionIndex;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject wrongAnsPanel;

    public void StartGame()
    {
        Debug.Log("Start game");

        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;

        playerHp = playerHpSetting;
        //bossHp = bossHpSetting; 
        //gruntCount = gruntCountSetting;
        playerObj.GetComponentInChildren<PlayerHpGraphicControl>().AddHearts(playerHp);
        stageCleared = false;
        EnemyLineControl.Instance.StartGrunts();

        timer = -1;
        InvokeRepeating("Timer", 0f, 1f);
        questionIndex = 0;
        isRoundActive = true;

        ShowQuestion();
    }
    public void EndGame(bool endByQuit)
    {
        Debug.Log("End game");
        isRoundActive = false;
        if (endByQuit)
        {
            ClearGameStatus();
            return;
        }
        if (stageCleared)
        {
            ShowPanel(winPanel);
        }
        else
        {
            ShowPanel(losePanel);
        }
    }
    public void ShowPanel(GameObject panel)
    {
        isRoundActive = false;
        panel.SetActive(true);
    }
    public void ResumeRound()
    {
        isRoundActive = true;
    }
    public void ClearGameStatus()
    {
        playerObj.GetComponentInChildren<PlayerHpGraphicControl>().RemoveHearts(playerHp);
        EnemyLineControl.Instance.DeleteEnemyLine();
        foreach (GameObject fx in GameObject.FindGameObjectsWithTag("FX"))
        {
            Destroy(fx);
        }
    }
    private void Timer()
    {
        if (isRoundActive)
        {
            timer++;
            timerText.SetText("Time: " + timer.ToString());
        }
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
            EffectSpawner.Instance.SpawnEffectAtCursor(EffectSpawner.Instance.feedbackCorrect, gameObject);

            if (questionIndex + 1 >= questionPool.Length)
            {
                Debug.Log("Stage cleared");
                stageCleared = true;
                EndGame(false);
            }
            else
            {
                questionIndex++;
                EnemyLineControl.Instance.CycleGrunts();
                ShowQuestion();
            }
        }
        else
        {
            Debug.Log("Wrong answer");
            EffectSpawner.Instance.SpawnEffectAtCursor(EffectSpawner.Instance.feedbackIncorrect, gameObject);

            playerHp--;
            playerObj.GetComponentInChildren<PlayerHpGraphicControl>().RemoveHearts(1);
            ShowPanel(wrongAnsPanel);

            if (playerHp <= 0)
            {
                Debug.Log("No more HP");
                EndGame(false);
            }
        }
    }
    public QuestionData[] GetQuestionPool()
    {
        return questionPool;
    }
    public int GetQuestionIndex()
    {
        return questionIndex;
    }
}
