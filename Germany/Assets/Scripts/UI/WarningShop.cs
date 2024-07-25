using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarningShop : MonoBehaviour
{
    [SerializeField] Skins skin;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI description;

    public void SetSkin(Skins skin)
    {
        this.skin = skin;
        image.sprite = skin.sprite;
        description.text = skin.description;
    }

    public void Confirm()
    {
        GameManager.Instance.IncreaseCoins(-skin.price);
        skin.bought = true;
        gameObject.SetActive(false);
        GlobalActions.onBoughtSkin?.Invoke();
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
