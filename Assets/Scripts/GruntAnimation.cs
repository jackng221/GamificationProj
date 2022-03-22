using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GruntAnimation : MonoBehaviour
{
    [SerializeField]
    Transform initPos;

    [SerializeField]
    GameObject[] positions;

    [SerializeField]
    GameObject[] grunts;

    [SerializeField]
    GameObject[] gruntList;

    public float moveTime = 0.5f;

    private void Start()
    {
        grunts = new GameObject[positions.Length];
        gruntList = GameObject.FindGameObjectsWithTag("Grunt");
        for (int i = 0; i < positions.Length; i++)
        {
            bool pass;
            int x;
            do
            {
                pass = true;
                x = Random.Range(0, gruntList.Length);
                for (int j = 0; j < i; j++) //check duplicate
                {
                    if (gruntList[x].name == grunts[j].name)
                    {
                        pass = false;
                    }
                }
            } while (!pass);
            grunts[i] = gruntList[x];

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CycleGrunts();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ReturnToSpawn();
        }
    }
    public void CycleGrunts()
    {
        for (int i = 0; i < grunts.Length; i++)
        {
            if (i == 0) // return to grunt list
            {
                grunts[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
                grunts[i].transform.SetParent(initPos);
                grunts[i].transform.DOMove(initPos.position, moveTime);
            }
            else
            {
                grunts[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = i + 1;
                grunts[i].transform.SetParent(positions[i - 1].transform);
                grunts[i].transform.DOMove(positions[i - 1].transform.position, moveTime);
            }
        }

        // get new random grunt
        bool pass;
        int x;
        do
        {
            pass = true;
            x = Random.Range(0, gruntList.Length);
            for (int i = 0; i < grunts.Length; i++) //check duplicate
            {
                if (gruntList[x].name == grunts[i].name)
                {
                    pass = false;
                }
            }
        } while (!pass);
        gruntList[x].transform.SetParent(positions[positions.Length - 1].transform);
        gruntList[x].transform.DOMove(positions[positions.Length - 1].transform.position, moveTime);

        for (int i = 0; i < grunts.Length; i++)
        {
            grunts[i] = positions[i].transform.GetChild(0).gameObject;
        }

    }
    public void ReturnToSpawn()
    {
        foreach (GameObject grunt in grunts)
        {
            grunt.transform.DOMove(initPos.position, 0.5f);
        }
    }
}
