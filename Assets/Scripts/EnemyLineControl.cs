using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyLineControl : MonoBehaviour
{
    private static EnemyLineControl instance;
    public static EnemyLineControl Instance
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

        //gruntList = GameObject.FindGameObjectsWithTag("Grunt");
    }

    [SerializeField]
    private QuestionData[] questionPool;
    [SerializeField]
    private int questionIndex;

    public GameObject charChef;
    public GameObject charCloud;
    public GameObject charCooking;
    public GameObject charEgg;
    public GameObject charForecast;
    public GameObject charMeat;
    public GameObject charMicrowave;
    public GameObject charRain;
    public GameObject charRefrigerator;
    public GameObject charSun;
    public GameObject charThunder;
    public GameObject charTornado;
    public GameObject charWashing;
    public GameObject charWinter;

    [SerializeField]
    Transform initPos;

    [SerializeField]
    Transform[] positions;

    [SerializeField]
    GameObject[] grunts;

    //[SerializeField]
    //GameObject[] gruntList;

    public float tweenTime = 1f;
    public Ease tweenType = Ease.OutQuint;

    public void StartGrunts()
    {
        Debug.Log("Start grunts");

        questionPool = GameController.Instance.GetQuestionPool();
        grunts = new GameObject[questionPool.Length];

        for (int i = 0; i < questionPool.Length; i++)
        {
            switch (questionPool[i].graphic)
            {
                case "charChef":
                    grunts[i] = Instantiate(charChef, initPos);
                    break;
                case "charCloud":
                    grunts[i] = Instantiate(charCloud, initPos);
                    break;
                case "charCooking":
                    grunts[i] = Instantiate(charCooking, initPos);
                    break;
                case "charEgg":
                    grunts[i] = Instantiate(charEgg, initPos);
                    break;
                case "charForecast":
                    grunts[i] = Instantiate(charForecast, initPos);
                    break;
                case "charMeat":
                    grunts[i] = Instantiate(charMeat, initPos);
                    break;
                case "charMicrowave":
                    grunts[i] = Instantiate(charMicrowave, initPos);
                    break;
                case "charRain":
                    grunts[i] = Instantiate(charRain, initPos);
                    break;
                case "charRefrigerator":
                    grunts[i] = Instantiate(charRefrigerator, initPos);
                    break;
                case "charSun":
                    grunts[i] = Instantiate(charSun, initPos);
                    break;
                case "charThunder":
                    grunts[i] = Instantiate(charThunder, initPos);
                    break;
                case "charTornado":
                    grunts[i] = Instantiate(charTornado, initPos);
                    break;
                case "charWashing":
                    grunts[i] = Instantiate(charWashing, initPos);
                    break;
                case "charWinter":
                    grunts[i] = Instantiate(charWinter, initPos);
                    break;
                default:
                    Debug.Log("Error: question graphic not found");
                    break;
            }
        }

        questionIndex = GameController.Instance.GetQuestionIndex();
        for (int i = 0; i < positions.Length; i++)
        {
            grunts[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = positions.Length - i;
            grunts[i].transform.DOMove(positions[i].position, tweenTime).SetEase(tweenType);
            grunts[i].transform.SetParent(positions[i]);
        }
        //grunts = new GameObject[positions.Length];

        //for (int i = 0; i < positions.Length; i++)
        //{
        //    bool pass;
        //    int rand;
        //    do
        //    {
        //        pass = true;
        //        rand = Random.Range(0, gruntList.Length);
        //        for (int j = 0; j < i; j++) //check duplicate
        //        {
        //            if (gruntList[rand].name == grunts[j].name)
        //            {
        //                pass = false;
        //            }
        //        }
        //    } while (!pass);
        //    grunts[i] = gruntList[rand];
        //}
        //CycleGrunts();
    }
    public void CycleGrunts()
    {
        questionIndex = GameController.Instance.GetQuestionIndex();

        positions[0].GetChild(0).GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
        positions[0].GetChild(0).transform.DOMove(initPos.position, tweenTime).SetEase(tweenType);
        positions[0].GetChild(0).transform.SetParent(initPos);

        if (grunts.Length - questionIndex >= positions.Length)  //enough questions to fill all positions
        {
            for (int i = 0; i < positions.Length; i++)
            {
                grunts[i + questionIndex].GetComponentInChildren<SpriteRenderer>().sortingOrder = positions.Length - i;
                grunts[i + questionIndex].transform.SetParent(positions[i]);
            }
        }
        else
        {
            for (int i = 0; i < grunts.Length - questionIndex; i++)
            {
                grunts[i + questionIndex].GetComponentInChildren<SpriteRenderer>().sortingOrder = (grunts.Length - questionIndex) - i;
                grunts[i + questionIndex].transform.SetParent(positions[i]);
            }
        }

        foreach (GameObject grunt in grunts)
        {
            grunt.transform.DOMove(grunt.transform.parent.position, tweenTime).SetEase(tweenType);
        }

        //for (int i = 0; i < grunts.Length; i++)
        //{
        //    grunts[i] = positions[i].GetChild(0).gameObject;
        //}

        //for (int i = 0; i < grunts.Length; i++)
        //{
        //    if (i == 0) // return to grunt list
        //    {
        //        foreach (SpriteRenderer sr in grunts[i].GetComponentsInChildren<SpriteRenderer>())
        //        {
        //            sr.sortingOrder = 0;
        //        }
        //        //grunts[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
        //        grunts[i].transform.SetParent(positions[0]);
        //        grunts[i].transform.DOMove(positions[0].position, tweenTime).SetEase(tweenType);
        //    }
        //    else
        //    {
        //        foreach(SpriteRenderer sr in grunts[i].GetComponentsInChildren<SpriteRenderer>())
        //        {
        //            sr.sortingOrder = grunts.Length - i;
        //        }
        //        //grunts[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = i + 1;
        //        grunts[i].transform.SetParent(positions[i - 1]);
        //        grunts[i].transform.DOMove(positions[i - 1].position, tweenTime).SetEase(tweenType);
        //    }
        //}

        // get new random grunt
        //bool pass;
        //int rand;
        //do
        //{
        //    pass = true;
        //    rand = Random.Range(0, gruntList.Length);
        //    for (int i = 0; i < grunts.Length; i++) //check duplicate
        //    {
        //        if (gruntList[rand].name == grunts[i].name)
        //        {
        //            pass = false;
        //        }
        //    }
        //} while (!pass);
        //gruntList[rand].transform.SetParent(positions[positions.Length - 1]);
        //gruntList[rand].transform.DOMove(positions[positions.Length - 1].position, tweenTime).SetEase(tweenType);
    }
    public void DeleteEnemyLine()
    {
        Debug.Log("Delete enemy line");

        GameObject[] toBeDeleted = GameObject.FindGameObjectsWithTag("Grunt");
        foreach (GameObject grunt in toBeDeleted)
        {
            Destroy(grunt);
        }

        //foreach (GameObject grunt in gruntList)
        //{
        //    grunt.transform.DOKill();
        //    grunt.transform.DOMove(positions[0].position, tweenTime);
        //    grunt.transform.SetParent(positions[0]);
        //}
        //grunts = new GameObject[positions.Length];
    }
}
