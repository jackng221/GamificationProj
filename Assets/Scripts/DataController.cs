using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private static DataController instance;
    public static DataController Instance
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

    public RoundData[] allRoundData;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public RoundData GetRoundData(int roundIndex)
    {
        return allRoundData[roundIndex];
    }
}
