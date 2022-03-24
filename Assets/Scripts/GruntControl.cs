using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GruntControl : MonoBehaviour
{
    private static GruntControl instance;
    public static GruntControl Instance
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

        gruntList = GameObject.FindGameObjectsWithTag("Grunt");
    }

    [SerializeField]
    Transform initPos;

    [SerializeField]
    Transform[] positions;

    [SerializeField]
    GameObject[] grunts;

    [SerializeField]
    GameObject[] gruntList;

    public float tweenTime = 1f;
    public Ease tweenType = Ease.OutQuint;

    public void StartGrunts()
    {
        grunts = new GameObject[positions.Length];

        for (int i = 0; i < positions.Length; i++)
        {
            bool pass;
            int rand;
            do
            {
                pass = true;
                rand = Random.Range(0, gruntList.Length);
                for (int j = 0; j < i; j++) //check duplicate
                {
                    if (gruntList[rand].name == grunts[j].name)
                    {
                        pass = false;
                    }
                }
            } while (!pass);
            grunts[i] = gruntList[rand];
        }
        CycleGrunts();
    }
    public void CycleGrunts()
    {
        for (int i = 0; i < grunts.Length; i++)
        {
            if (i == 0) // return to grunt list
            {
                grunts[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
                grunts[i].transform.SetParent(initPos);
                grunts[i].transform.DOMove(initPos.position, tweenTime).SetEase(tweenType);
            }
            else
            {
                grunts[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = i + 1;
                grunts[i].transform.SetParent(positions[i - 1]);
                grunts[i].transform.DOMove(positions[i - 1].position, tweenTime).SetEase(tweenType);
            }
        }

        // get new random grunt
        bool pass;
        int rand;
        do
        {
            pass = true;
            rand = Random.Range(0, gruntList.Length);
            for (int i = 0; i < grunts.Length; i++) //check duplicate
            {
                if (gruntList[rand].name == grunts[i].name)
                {
                    pass = false;
                }
            }
        } while (!pass);
        gruntList[rand].transform.SetParent(positions[positions.Length - 1]);
        gruntList[rand].transform.DOMove(positions[positions.Length - 1].position, tweenTime).SetEase(tweenType);

        for (int i = 0; i < grunts.Length; i++)
        {
            grunts[i] = positions[i].GetChild(0).gameObject;
        }
    }
    public void ResetGrunts()
    {
        foreach (GameObject grunt in gruntList)
        {
            grunt.transform.DOKill();
            grunt.transform.DOMove(initPos.position, tweenTime);
            grunt.transform.SetParent(initPos);
        }

        grunts = new GameObject[positions.Length];
    }
}
