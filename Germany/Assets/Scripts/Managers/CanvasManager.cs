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

    [Space]
    [SerializeField] TextMeshProUGUI pointsText;


    //NOTE: return properties
    public GameObject ControlsPanel => controlsPanel;
    public GameObject MenuPanel => menuPanel;
    public GameObject EndGameMenu => endGameMenu;
    public GameObject UpPanel => upPanel;
    public GameObject LoadingPanel => loadingPanel;
    public TextMeshProUGUI PointsText => pointsText;
}
