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
    private int gruntCountSetting = 10;
    private int gruntCount;
    [SerializeField]
    private int bossHpSetting = 10;
    private int bossHp;

    private bool gruntClear = false;

    public void InitStage()
    {
        gruntCount = gruntCountSetting;
        bossHp = bossHpSetting;
        gruntClear = false;
    }
    public void QuitGame()
    {
        GruntControl.Instance.InitGrunts();
        SessionControl.Instance.GoToSession("Title");
    }
    private void Start()
    {
        InitStage();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !gruntClear)
        {
            KillGrunt();
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
            QuitGame();
        }
    }
}
