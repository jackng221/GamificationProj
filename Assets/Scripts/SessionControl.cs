using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionControl : MonoBehaviour
{
    [SerializeField]
    GameObject[] sessions;


    public void Start()
    {
        sessions[0].SetActive(true);
        if (sessions.Length > 1)
        {
            for (int i = 1; i < sessions.Length; i++)
            {
                sessions[i].SetActive(false);
            }
        }
    }
    public bool findSession(string session)
    {
        for (int i = 0; i < sessions.Length; i++)
        {
            if (sessions[i].name.Equals(session))
            {
                return true;
            }
        }
        Debug.Log("session not found");
        return false;
    }
    public void goToSession(string session)
    {
        if (findSession(session))
        {
            for (int i = 0; i < sessions.Length; i++)
            {

            }
        }
    }
}
