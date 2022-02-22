using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarController : MonoBehaviour
{

    // public methods
    public GameObject successPrefab;
    public GameObject failPrefab;

    public Vector3 defaultPoint = new Vector3(0f, 0f, 0f);
    public int maxTries = 99;
    public int iconsPerColumn = 5;
    public float xOffset = 1.5f;
    public float yOffset = -1f;

    // helper methods
    private int nextCounter = 1;
    private Vector3 nextPoint;

    void Start()
    {
        nextPoint = defaultPoint;
    }

    // public methods
    public void AddSuccess() 
    { 
        Instantiate(successPrefab, nextPoint, Quaternion.identity);
        IncrementInsertionPoint();
    }
    public void AddFail()
    {
        Instantiate(failPrefab, nextPoint, Quaternion.identity);
        IncrementInsertionPoint();
    }

    // helper methods
    private void IncrementInsertionPoint()
    {
        nextCounter++;
        if (nextCounter > iconsPerColumn) 
        { 
            nextCounter = nextCounter % iconsPerColumn;
            nextPoint = new Vector3(nextPoint.x + xOffset, defaultPoint.y, 0);
        }
        else
        {
            nextPoint += new Vector3(0, yOffset, 0);
        }
    }

}
