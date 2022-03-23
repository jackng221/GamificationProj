using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionControl : MonoBehaviour
{
    private static SessionControl instance;
    public static SessionControl Instance
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
        sessions = GameObject.FindGameObjectsWithTag("Session");
        GoToSession("Title");
    }
    private GameObject[] sessions;

    public bool FindSession(string session)
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
    public void GoToSession(string session)
    {
        if (FindSession(session))
        {
            for (int i = 0; i < sessions.Length; i++)
            {
                if (sessions[i].name.Equals(session))
                {
                    sessions[i].SetActive(true);
                }
                else
                {
                    sessions[i].SetActive(false);
                }
            }
        }
    }
}
