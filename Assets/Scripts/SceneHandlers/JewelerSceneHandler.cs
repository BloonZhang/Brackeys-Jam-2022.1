using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelerSceneHandler : MonoBehaviour
{
    //////// Singleton shenanigans ////////
    private static JewelerSceneHandler _instance;
    public static JewelerSceneHandler Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    // Controllers
    public ProgressBarController progressBarController;

    // public gameobjects
    public GameObject blocker;
    public GameObject swapMenu;

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
        // find the ProgressBarController
        if (progressBarController == null) { progressBarController = GetComponent<ProgressBarController>(); }
    }

    void Start()
    {
        // diable pause menu blocker
        blocker.SetActive(false); swapMenu.SetActive(false);
    }

    // public methods
    public void OpenSwapMenu()
    {
        blocker.SetActive(true); swapMenu.SetActive(true); 
        ClickableController.DisableAll();
    }
    public void CloseSwapMenu()
    {
        blocker.SetActive(false); swapMenu.SetActive(false);
        ClickableController.EnableAll();
    }
}
