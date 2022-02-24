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
    public TextMeshProUGUI forceSuccessText;

    // public variables
    public int forceSuccessMax = 3;
    private int forceSuccessRemaining;

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
        forceSuccessRemaining = forceSuccessMax; forceSuccessText.text = "Remaining: " + forceSuccessRemaining;

        // Debug Stats.cs
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
    public int ForceSuccessRemaining() { return forceSuccessRemaining; }
    public bool UseForceSuccess()
    {
        if ( forceSuccessRemaining <= 0 ) { return false; }
        forceSuccessRemaining -= 1; forceSuccessText.text = "Remaining: " + forceSuccessRemaining;
        return true;
    }
    public void FinishFaceting()
    {
        // TODO: something about the Diamond
        Diamond finishedDiamond = diamondController.GetDiamond();
        int counter = 1;
        foreach(bool facetResult in finishedDiamond.GetResult())
        {
            Debug.Log(counter + ": " + facetResult);
            counter++;
        }
    }
}
