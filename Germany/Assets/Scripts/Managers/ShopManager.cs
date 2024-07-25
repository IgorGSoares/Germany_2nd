using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] SkinShopUI[] skins;
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
}
