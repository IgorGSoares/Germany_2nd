using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsAquiredUI : MonoBehaviour
{
    [SerializeField] Color color= Color.gray;
    [SerializeField] Skins skin;
    [SerializeField] Image image;
    [SerializeField] WarningSkin warningSkin;

    public Skins Skins => skin;
    

    void OnEnable()
    {
        GlobalActions.onSkinEquipped += ResetSkin;
        GlobalActions.onSkinEquipped += ConfirmEquip;
    }

    void OnDisable()
    {
        GlobalActions.onSkinEquipped -= ConfirmEquip;
        GlobalActions.onSkinEquipped -= ResetSkin;
    }

    void Start()
    {
        image.sprite = skin.sprite;
        if(skin.selected) image.color = color;
        else image.color = Color.white;
    }

    public void EquipSkin()
    {
        if(skin.selected) return;

        warningSkin.gameObject.SetActive(true);
        warningSkin.SetSkinToEquip(skin);
    }

    void ConfirmEquip(string ID)
    {
        if(skin.ID != ID) return;

        image.color = color;
        GameManager.Instance.PlayerSpriteRenderer.sprite = skin.sprite;

        GameManager.Instance.ChangeCurrentSkin(skin.ID);
    }

    void ResetSkin(string ID)
    {
        if(skin.ID == ID) return;

        image.color = Color.white;
    }
}
