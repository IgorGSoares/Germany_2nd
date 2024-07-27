using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsAquiredUI : MonoBehaviour
{
    [SerializeField] Color color= Color.gray;
    [SerializeField] Skins skin;
    [SerializeField] Image image;
    

    void OnEnable()
    {
        if(skin.selected) image.color = color;
    }

    public void EquipSkin()
    {
        
    }
}
