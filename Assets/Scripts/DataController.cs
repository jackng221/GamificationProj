using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }
}
