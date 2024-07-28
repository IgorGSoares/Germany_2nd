using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    [SerializeField] SkinsAquiredUI[] skinsAquirred;
    void Start()
    {
        //GlobalActions.onBoughtSkin += UpdateAquirredSkins;

        foreach (var sk in skinsAquirred)
        {
            if (!sk.Skins.selected) sk.gameObject.SetActive(false);
        }
    }

    // void OnDisable()
    // {
    //     GlobalActions.onBoughtSkin -= UpdateAquirredSkins;
    // }

    public void UpdateAquirredSkins()
    {
        foreach (var sk in skinsAquirred)
        {
            if (sk.Skins.bought) 
            {
                sk.gameObject.SetActive(true);
                // Debug.Log(sk.gameObject.activeSelf);
            }
        }
    }
}
