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
    [SerializeField] WarningSkin warningShop;

    public Skins Skin => skin;

    void OnEnable()
    {
        //GlobalActions

        price.text = skin.price.ToString();
        if(GameManager.Instance.Coins < skin.price) price.color = Color.red;
        else price.color = Color.green;

        image.sprite = skin.sprite;
    }

    // void OnDisable()
    // {
        
    // }

    public void BuySkin()
    {
        //if(GameManager.Instance.Coins < skin.price) return;

        warningShop.SetSkinToBuy(skin);
        warningShop.gameObject.SetActive(true);
    }

    public void CheckColor()
    {
        if(GameManager.Instance.Coins < skin.price) price.color = Color.red;
        else price.color = Color.green;
    }

    // void BoughtSkin()
    // {

    // }
}
