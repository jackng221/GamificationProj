using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    [SerializeField] GameObject achievementItem; //prefab

    public GameObject achievementPopUp;
    public GameObject scrollViewContent;
    public Progress[] progresses;

    public int wrongAnsCount = 0;

    public void TriggerAchievement(Progress.Names progressEnum)
    {
        for (int i = 0; i < progresses.Length; i++)
        {
            if (progresses[i].progressEnum == progressEnum)
            {
                if (progresses[i].isAchieved == 1) { return; }

                progresses[i].isAchieved = 1;
                progresses[i].dateText = "\n" + System.DateTime.Today.ToString("yyyy - mm - dd");
                GameObject item = Instantiate(achievementItem, scrollViewContent.transform, false);
                item.GetComponent<AchievementItem>().SetAttribute(progresses[i].text + progresses[i].dateText, progresses[i].sprite);

                achievementPopUp.GetComponentInChildren<AchievementItem>().SetAttribute(progresses[i].text + progresses[i].dateText, progresses[i].sprite);
                break;
            }
        }
        AchievementPopUp();
        SaveProgress();
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GetProgress();
    }
    public void GetProgress()
    {
        foreach (Progress progress in progresses) {
            progress.isAchieved = PlayerPrefs.GetInt(progress.progressEnum.ToString(), 0);
            progress.dateText = PlayerPrefs.GetString(progress.progressEnum.ToString() + "Date");
        }

        for (int i = 0; i < progresses.Length; i++)
        {
            if (progresses[i].isAchieved == 1)
            {
                GameObject item = Instantiate(achievementItem, scrollViewContent.transform, false);
                item.GetComponent<AchievementItem>().SetAttribute(progresses[i].text + progresses[i].dateText, progresses[i].sprite);
            }
        }
        wrongAnsCount = PlayerPrefs.GetInt("wrongAnsCount", 0);

    }
    public void SaveProgress()
    {
        foreach (Progress progress in progresses)
        {
            PlayerPrefs.SetInt(progress.progressEnum.ToString(), progress.isAchieved);
            PlayerPrefs.SetString(progress.progressEnum.ToString()+"Date", progress.dateText);
        }
        PlayerPrefs.SetInt("wrongAnsCount", wrongAnsCount);

    }
    public void ClearProgress()
    {
        PlayerPrefs.DeleteAll();
        foreach (Progress progress in progresses)
        {
            progress.isAchieved = 0;
            progress.dateText = "";
        }
        foreach (Transform child in scrollViewContent.transform)
        {
            Destroy(child.gameObject);
        }
        wrongAnsCount = 0;

}
    public void WrongAnsCountAdd(int amount)
    {
        wrongAnsCount += amount;
        if (wrongAnsCount >= 10)
        {
            TriggerAchievement(Progress.Names.Wrong10);
            //wrongAns50Times = 1;
        }
    }
    private void AchievementPopUp()
    {
        Vector3 ogLocalPosition = achievementPopUp.transform.localPosition;
        Sequence sequence = DOTween.Sequence()
            .Append(achievementPopUp.transform.DOLocalMoveY(ogLocalPosition.y + 285, 1f).SetEase(Ease.OutQuad))
            .AppendInterval(2f)
            .Append(achievementPopUp.transform.DOLocalMoveY(ogLocalPosition.y, 1f).SetEase(Ease.InQuad)).OnKill( ()=> achievementPopUp.transform.localPosition = ogLocalPosition);
    }
}
