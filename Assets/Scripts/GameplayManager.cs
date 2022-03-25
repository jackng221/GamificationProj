using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private static GameplayManager instance;
    public static GameplayManager Instance
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
    [SerializeField]
    private int bossHpSetting = 10;
    private int bossHp;
    [SerializeField]
    private int gruntCountSetting = 10;
    private int gruntCount;

    private bool gruntClear = false;

    public void StartGame()
    {
        Debug.Log("Start game");
        playerHp = playerHpSetting;
        bossHp = bossHpSetting; 
        gruntCount = gruntCountSetting;
        gruntClear = false;
        GruntControl.Instance.StartGrunts();
        QuestionAnswerLogic.Instance.NewQuestion();
    }
    public void EndGame()
    {
        Debug.Log("End game");
        GruntControl.Instance.ResetGrunts();
        if (gruntClear)
        {
            BossControl.Instance.ResetBoss();
        }
        SessionControl.Instance.GoToSession("Title");
    }
    public void Answer(bool correct)
    {
        if (correct)
        {
            Debug.Log("Correct answer");
            if (!gruntClear)
            {
                KillGrunt();
                QuestionAnswerLogic.Instance.NewQuestion();
            }
            else
            {
                DamageBoss();
                QuestionAnswerLogic.Instance.NewQuestion();
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
    private void KillGrunt()
    {
        Debug.Log("Kill grunt");
        gruntCount--;
        if (gruntCount <= 0)
        {
            Debug.Log("Grunt cleared");
            gruntClear = true;
            GruntControl.Instance.ResetGrunts();
            StartBoss();
        }
        else
        {
            GruntControl.Instance.CycleGrunts();
        }
    }

    private void StartBoss()
    {
        BossControl.Instance.StartBoss();
    }
    private void DamageBoss()
    {
        Debug.Log("Damage boss");
        bossHp--;
        if (bossHp <= 0)
        {
            Debug.Log("Stage clear");
            EndGame();
        }
    }
}
