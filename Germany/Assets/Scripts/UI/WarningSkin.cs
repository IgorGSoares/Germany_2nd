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
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] FeedbackEffect feedbackEffect;

    //SkinsAquiredUI curSkinAquired;

    public void SetSkinToBuy(Skins skin)
    {
        this.skin = skin;
        image.sprite = skin.sprite;
        description.text = skin.description;
        name.text = skin.nameSkin;

        feedbackEffect.gameObject.SetActive(true);
    }

    public void SetSkinToEquip(Skins skin) //, SkinsAquiredUI skinsAquiredUI
    {
        this.skin = skin;
        image.sprite = skin.sprite;
        description.text = skin.description;
        name.text = skin.nameSkin;

        //curSkinAquired = skinsAquiredUI;
    }

    public void ConfirmBuy()
    {
        if(skin.price <= GameManager.Instance.Coins)
        {
            GameManager.Instance.IncreaseCoins(-skin.price);
            skin.bought = true;
            GlobalActions.onBoughtSkin?.Invoke();
            GameManager.Instance.SaveGame();
            feedbackEffect.SetText("Compra Concluída");
        }
        else feedbackEffect.SetText("Compra Inválida");

        gameObject.SetActive(false);
    }

    public void ConfirmEquip()
    {
        //GameManager.Instance.IncreaseCoins(-skin.price);
        skin.selected = true;
        gameObject.SetActive(false);
        GlobalActions.onSkinEquipped?.Invoke(skin.ID);
        GameManager.Instance.SaveGame();
        //GlobalActions.onBoughtSkin?.Invoke();
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
