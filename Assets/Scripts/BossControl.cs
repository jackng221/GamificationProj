using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossControl : MonoBehaviour
{
    private static BossControl instance;
    public static BossControl Instance
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

        bossList = GameObject.FindGameObjectsWithTag("Boss");
    }

    [SerializeField]
    Transform initPos;

    [SerializeField]
    Transform pos;

    [SerializeField]
    GameObject boss;

    [SerializeField]
    GameObject[] bossList;

    public float tweenTime = 1f;
    public Ease tweenType = Ease.OutQuint;

    public void StartBoss()
    {
        int rand = Random.Range(0, bossList.Length);
        boss = bossList[rand];

        boss.transform.DOMove(pos.position, tweenTime).SetEase(tweenType);
        boss.transform.SetParent(pos);
    }
    public void ResetBoss()
    {
        boss.transform.DOKill();
        boss.transform.DOMove(initPos.position, tweenTime);
        boss.transform.SetParent(initPos);
    }
}
