using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{

    // public variables
    public Diamond currentDiamond;

    // private variables
    // numberOfSuccesses = 0;
    // numberOfFailures = 0;

    void Start()
    {

    }

    // public methods
    public bool FacetDiamond()
    {
        // If 100% success rate
        if (currentDiamond.successRate == 1.0f) { return true; }

        // Otherwise, generate random number
        float randomValue = Random.value;
        if (randomValue < currentDiamond.successRate) 
        { 
            // numberOfSuccesses += 1;
            return true; 
        }
        else 
        { 
            // numberOfFailures += 1;
            return false; 
        }
    }
    public void SetCurrentDiamond(Diamond diamond)
    {
        currentDiamond = diamond;
        // numberOfSuccesses = 0; numberOfFailures = 0;
    }

}
