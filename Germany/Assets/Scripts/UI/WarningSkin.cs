using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarningSkin : MonoBehaviour
{
    [SerializeField] Skins skin;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI description;

    //SkinsAquiredUI curSkinAquired;

    public void SetSkinToBuy(Skins skin)
    {
        this.skin = skin;
        image.sprite = skin.sprite;
        description.text = skin.description;
    }

    public void SetSkinToEquip(Skins skin) //, SkinsAquiredUI skinsAquiredUI
    {
        this.skin = skin;
        image.sprite = skin.sprite;
        description.text = skin.description;

        //curSkinAquired = skinsAquiredUI;
    }

    public void ConfirmBuy()
    {
        GameManager.Instance.IncreaseCoins(-skin.price);
        skin.bought = true;
        gameObject.SetActive(false);
        GlobalActions.onBoughtSkin?.Invoke();
    }

    public void ConfirmEquip()
    {
        //GameManager.Instance.IncreaseCoins(-skin.price);
        skin.selected = true;
        gameObject.SetActive(false);
        GlobalActions.onSkinEquipped?.Invoke(skin.ID);
        //GlobalActions.onBoughtSkin?.Invoke();
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
