using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    //NOTE: panels
    [SerializeField] GameObject controlsPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject endGameMenu;
    [SerializeField] GameObject upPanel;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] GameObject collectionPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject pausePanel;

    [Space]
    [SerializeField] TextMeshProUGUI pointsText;


    //NOTE: return properties
    public GameObject ControlsPanel => controlsPanel;
    public GameObject MenuPanel => menuPanel;
    public GameObject EndGameMenu => endGameMenu;
    public GameObject UpPanel => upPanel;
    public GameObject LoadingPanel => loadingPanel;
    public GameObject ShopPanel => shopPanel;
    public GameObject CollectionPanel => collectionPanel;
    //public GameObject PausePanel => pausePanel;
    public TextMeshProUGUI PointsText => pointsText;


    //NOTE: methods
    public void ShowGameControls()
    {
        if(controlsPanel.activeSelf) return;

        controlsPanel.SetActive(true);
        shopPanel.SetActive(false);
        collectionPanel.SetActive(false);
        upPanel.SetActive(false);
    }

    public void ShowShopPanel()
    {
        if(shopPanel.activeSelf) return;

        controlsPanel.SetActive(false);
        shopPanel.SetActive(true);
        collectionPanel.SetActive(false);
        upPanel.SetActive(false);
    }

    public void ShowCollectionPanel()
    {
        if(collectionPanel.activeSelf) return;

        controlsPanel.SetActive(false);
        shopPanel.SetActive(false);
        upPanel.SetActive(false);
        collectionPanel.SetActive(true);
    }

    public void PausePanel(bool b)
    {
        pausePanel.SetActive(b);
        upPanel.SetActive(!b);
    }
}
