using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    private static ProgressController instance;
    public static ProgressController Instance
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
    public int wrongAnsCount = 0;

    public int perfectClearWeather = 0;
    public int perfectClearFoodSafety = 0;
    public int wrongAns50Times = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GetProgress();
    }
    public void GetProgress()
    {
        wrongAnsCount = PlayerPrefs.GetInt("wrongAnsCount", 0);
        perfectClearWeather = PlayerPrefs.GetInt("perfectClearWeather", 0);
        perfectClearFoodSafety = PlayerPrefs.GetInt("perfectClearFoodSafety", 0);
        wrongAns50Times = PlayerPrefs.GetInt("wrongAns50Times", 0);
    }
    public void SaveProgress()
    {
        PlayerPrefs.SetInt("wrongAnsCount", wrongAnsCount);
        PlayerPrefs.SetInt("perfectClearWeather", perfectClearWeather);
        PlayerPrefs.SetInt("perfectClearFoodSafety", perfectClearFoodSafety);
        PlayerPrefs.SetInt("wrongAns50Times", wrongAns50Times);
    }
    public void ClearProgress()
    {
        PlayerPrefs.DeleteAll();
        wrongAnsCount = 0;
        perfectClearWeather = 0;
        perfectClearFoodSafety = 0;
        wrongAns50Times = 0;
}
    public void WrongAnsCountAdd(int amount)
    {
        wrongAnsCount += amount;
        if (wrongAnsCount >= 50)
        {
            wrongAns50Times = 1;
        }
    }
}
