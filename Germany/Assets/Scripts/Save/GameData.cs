using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //VERSION
    public string version;

    //STATUS
    public int coins;
    public string equippedSkin;
    public bool[] boughtSkins;

    //PROGRESS
    // public int[] progress;
    // public bool isTutorialForge;
    // public bool isTutorialShop;


    public GameData(int coins, bool[] boughtSkins, string equippedSkin)
    {
        version = Application.version;

        this.coins = coins;
        this.equippedSkin = equippedSkin;

        this.boughtSkins = new bool[boughtSkins.Length];
        for (int i = 0; i < boughtSkins.Length; i++)
        {
            this.boughtSkins[i] = boughtSkins[i];
        }
    }
}
