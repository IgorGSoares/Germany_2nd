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
        yield return new WaitForSeconds(5);

        gameObject.transform.DOScale(0.01f, 2.5f).SetEase(Ease.Linear).OnComplete(() => {gameObject.SetActive(false); });
    }
}
