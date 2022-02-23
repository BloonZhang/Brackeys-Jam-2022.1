using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JewelerSceneHandler : MonoBehaviour
{
    //////// Singleton shenanigans ////////
    private static JewelerSceneHandler _instance;
    public static JewelerSceneHandler Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    // Controllers
    public ProgressBarController progressBarController;
    public DiamondController diamondController;


    // public gameobjects
    public GameObject blocker;
    public GameObject swapMenu;
    public TextMeshProUGUI selectedPercentageText;

    // private variables
    private float selectedPercentage = 0.0f;

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

    void Start()
    {
        // diable pause menu blocker
        blocker.SetActive(false); swapMenu.SetActive(false);
    }

    // public methods
    public void OpenSwapMenu()
    {
        selectedPercentage = 0.0f; selectedPercentageText.text = "-- %";
        blocker.SetActive(true); swapMenu.SetActive(true); 
        ClickableController.DisableAll();
    }
    public void CloseSwapMenu()
    {
        blocker.SetActive(false); swapMenu.SetActive(false);
        ClickableController.EnableAll();
    }
    public void SetPercentage(float percentage) 
    { 
        selectedPercentageText.text = System.String.Format("{0:P0}", percentage);
        selectedPercentage = percentage; 
    }
    public void SelectPercentage()
    {
        // TODO: display error message telling player to select a percentage
        if (selectedPercentage == 0.0f) { return; }
        // Create diamond and give to diamondcontroller
        diamondController.SetCurrentDiamond(new Diamond(selectedPercentage));
        CloseSwapMenu();
    }
}
