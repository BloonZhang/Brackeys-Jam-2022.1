using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{

    // public GameObjects
    public GameObject successPrefab;
    public GameObject failPrefab;
    public Button swapButton;
    public Button finishButton;

    public Vector3 defaultPoint = new Vector3(0f, 0f, 0f);
    public int minTries = 5;
    public int maxTries = 99;
    public int iconsPerColumn = 5;
    public float xOffset = 1.5f;
    public float yOffset = -1f;

    // helper variables
    private int nextCounter = 1;
    private Vector3 nextPoint;

    void Start()
    {
        Reset();
    }

    // public methods
    public void AddSuccess() 
    {
        if (nextCounter > maxTries) { return; }
        Instantiate(successPrefab, nextPoint, Quaternion.identity);
        IncrementInsertionPoint();
    }
    public void AddFail()
    {
        if (nextCounter > maxTries) { return; }
        Instantiate(failPrefab, nextPoint, Quaternion.identity);
        IncrementInsertionPoint();
    }
    public void Reset()
    {
        nextPoint = defaultPoint;
        nextCounter = 1;
        swapButton.interactable = true;
        finishButton.interactable = false;
    }

    // helper methods
    private void IncrementInsertionPoint()
    {
        if (nextCounter % iconsPerColumn == 0) 
        { 
            nextPoint = new Vector3(nextPoint.x + xOffset, defaultPoint.y, 0);
        }
        else
        {
            nextPoint += new Vector3(0, yOffset, 0);
        }
        nextCounter++;
        // Turn off swap button, since we've faceted the diamond now
        swapButton.interactable = false;
        // Turn on finish button if met minimun tries
        if (nextCounter > minTries) { finishButton.interactable = true; }
    }

}
