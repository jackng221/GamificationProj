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
        playerHp = playerHpSetting;
        bossHp = bossHpSetting; 
        gruntCount = gruntCountSetting;
        gruntClear = false;
        GruntControl.Instance.CycleGrunts();
        QuestionAnswerLogic.Instance.NewQuestion();
    }
    public void EndGame()
    {
        GruntControl.Instance.InitGrunts();
        SessionControl.Instance.GoToSession("Title");
    }
    public void Answer(bool correct)
    {
        if (correct)
        {
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
            playerHp--;
            if (playerHp <= 0)
            {
                EndGame();
            }
        }
    }
    private void KillGrunt()
    {
        gruntCount--;
        if (gruntCount <= 0)
        {
            gruntClear = true;
            GruntControl.Instance.InitGrunts();
            StartBoss();
        }
        else
        {
            GruntControl.Instance.CycleGrunts();
        }
    }

    private void StartBoss()
    {
        Debug.Log("to do: boss battle");
    }
    private void DamageBoss()
    {
        bossHp--;
        if (bossHp <= 0)
        {
            Debug.Log("to do: stage clear");
            EndGame();
        }
    }
}
