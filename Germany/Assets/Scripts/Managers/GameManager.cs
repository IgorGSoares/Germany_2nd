using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //NOTE: managers
    [SerializeField] CanvasManager canvasManager;
    [SerializeField] ShopManager shopManager;
    [SerializeField] CollectionManager collectionManager;


    //NOTE: stats to save and modify
    [Space]
    [SerializeField] int coins;
    [SerializeField] Skins[] skins/* = new Skins[0]*/;
    [SerializeField] SpriteRenderer playerSpriteRenderer;


    //NOTE: variables
    bool isPaused = false;


    //NOTE: returning properties
    public CanvasManager CanvasManager => canvasManager;
    public int Coins => coins;
    public bool IsPaused => isPaused;
    public SpriteRenderer PlayerSpriteRenderer => playerSpriteRenderer;


    private void Awake() {
        Instance = this;
    }

    void Start()
    {
        ChangeSkinAtStart();
    }

    public void Restart()
    {
        canvasManager.LoadingPanel.SetActive(true);
        StartCoroutine(RestartGame());
    }

    public void IncreaseCoins(int amount)
    {
        coins += amount;
        canvasManager.PointsText.text = "Points: " + (coins.ToString());
    }

    public void ChangeSkinAtStart()
    {
        Sprite currSkin = null;

        foreach (var sk in skins)
        {
            if(sk.selected && sk.bought)
            {
                currSkin = sk.sprite;
                break;
            }
        }

        if (currSkin == null)
        {
            skins[0].selected = true;
            currSkin = skins[0].sprite;
        }

        playerSpriteRenderer.sprite = currSkin;
    }

    public void ChangeCurrentSkin(string skinName)
    {
        foreach (var sk in skins)
        {
            if(sk.selected && sk.ID != skinName)
            {
                sk.selected = false;
                break;
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        CanvasManager.PausePanel(true);

        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        isPaused = false;
        CanvasManager.PausePanel(false);
        
        Time.timeScale = 1;
    }
    
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
