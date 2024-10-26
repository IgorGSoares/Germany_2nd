using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class FeedbackEffect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textFeedback;
    void OnEnable()
    {
        StartCoroutine(Deactivate());
    }

    public void SetText(string t)
    {
        textFeedback.text = t;
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(1.5f);

        gameObject.transform.DOScale(0.01f, 0.5f).SetEase(Ease.OutQuint).OnComplete(() => {gameObject.SetActive(false); });
    }
}
