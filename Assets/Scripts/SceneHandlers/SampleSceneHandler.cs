using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSceneHandler : MonoBehaviour
{
    //////// Singleton shenanigans ////////
    private static SampleSceneHandler _instance;
    public static SampleSceneHandler Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    public ProgressBarController progressBarController;

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

    // Start is called before the first frame update
    void Start()
    {
        progressBarController = GetComponent<ProgressBarController>();
    }

}
