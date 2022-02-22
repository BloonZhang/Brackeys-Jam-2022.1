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

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
        
        if (progressBarController == null) { progressBarController = GetComponent<ProgressBarController>(); }
    }

    void Start()
    {

    }

}
