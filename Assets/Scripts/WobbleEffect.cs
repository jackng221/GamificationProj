using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class WobbleEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool requiresHover = false;
    public float tweenTime = 2f;
    public float tweenScale = 1.15f;
    private Vector3 originalScale;
    private Vector3 targetScale;
    private bool initScale = false;
    Sequence sequence;

    private void Start()
    {
        OnEnable();
    }
    private void OnEnable()
    {
        if (initScale == false)
        {
            originalScale = gameObject.transform.localScale;
            initScale = true;
        }

        gameObject.transform.localScale = originalScale;
        targetScale = originalScale * tweenScale;

        if (requiresHover == false)
        {
            sequence = DOTween.Sequence().Append(gameObject.transform.DOScale(targetScale, tweenTime))
            .Append(gameObject.transform.DOScale(originalScale * 1, tweenTime))
            .SetLoops(-1);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!requiresHover) { return; }

        Debug.Log("ENTER");
        sequence = DOTween.Sequence().Append(gameObject.transform.DOScale(targetScale, tweenTime))
        .Append(gameObject.transform.DOScale(originalScale * 1, tweenTime))
        .SetLoops(-1);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!requiresHover) { return; }

        Debug.Log("EXIT");
        sequence.Kill();
        gameObject.transform.localScale = originalScale;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!requiresHover) { return; }

        Debug.Log("CLICK");
        sequence.Kill();
        gameObject.transform.localScale = originalScale;
    }
}
