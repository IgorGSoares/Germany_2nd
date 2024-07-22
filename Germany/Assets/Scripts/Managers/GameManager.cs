using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //NOTE: managers
    [SerializeField] CanvasManager canvasManager;


    //NOTE: stats to save and modify
    [SerializeField] int coins;


    //NOTE: returning properties
    public CanvasManager CanvasManager => canvasManager;
    public int Coins => coins;

    
    private void Awake() {
        Instance = this;
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
    
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
