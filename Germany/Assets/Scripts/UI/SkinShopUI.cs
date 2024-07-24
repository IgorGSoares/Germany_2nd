using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinShopUI : MonoBehaviour
{
    [SerializeField] Skins skin;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI price;

    [Space]
    [SerializeField] WarningShop warningShop;

    void OnEnable()
    {
        price.text = skin.price.ToString();
        if(GameManager.Instance.Coins < skin.price) price.color = Color.red;
        else price.color = Color.green;

        image.sprite = skin.sprite;
    }
}
