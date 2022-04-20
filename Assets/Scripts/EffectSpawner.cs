using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    private static EffectSpawner instance;
    public static EffectSpawner Instance
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

    public GameObject canva;
    public GameObject feedbackCorrect;
    public GameObject feedbackIncorrect;

    public void SpawnEffectAtCursor(GameObject effectObj, GameObject parentUI)
    {
        Instantiate(effectObj, Camera.main.ScreenToWorldPoint(Input.mousePosition) + canva.transform.position, Quaternion.identity, parentUI.transform);
    }
}
