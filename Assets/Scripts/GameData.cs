using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private string[] subjects = { "A", "B", "C" };
    [SerializeField] Sprite[] subjectsIcons;

    public string[] getSubjects()
    {
        return subjects;
    }
}
