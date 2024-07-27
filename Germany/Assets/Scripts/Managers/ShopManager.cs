using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] SkinShopUI[] skins;
    [SerializeField] TextMeshProUGUI points;
    void Awake()
    {
        GlobalActions.onBoughtSkin += UpdateSkinsState;

        UpdateSkinsState();
    }

    void UpdateSkinsState()
    {
        foreach (var skin in skins)
        {
            if(skin.Skin.bought) skin.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        points.text = "Points: " + GameManager.Instance.Coins.ToString();
    }
}
