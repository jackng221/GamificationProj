using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpGraphicControl : MonoBehaviour
{
    public GameObject heartPrefab;
    [SerializeField] private List<GameObject> hearts;

    public void AddHearts(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            hearts.Add(Instantiate(heartPrefab, gameObject.transform));
        }
    }
    public void RemoveHearts(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject temp = hearts[hearts.Count - 1];
            hearts.RemoveAt(hearts.Count - 1);
            Destroy(temp);
        }
    }
}
