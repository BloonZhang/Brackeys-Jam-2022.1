using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{

    // public variables
    public Diamond currentDiamond;

    // private variables
    private ProgressBarController progressBarController;

    void Start()
    {
        progressBarController = SampleSceneHandler.Instance.progressBarController;
        currentDiamond = new Diamond(0.75f);
    }

    // public methods
    public void FacetDiamond()
    {
        // If 100% success rate
        if (currentDiamond.successRate == 1.0f) { SuccessFacet(); }

        // Otherwise, generate random number
        float randomValue = Random.value;
        if (randomValue < currentDiamond.successRate) { SuccessFacet(); }
        else { FailFacet(); }
    }
    public void SetCurrentDiamond(Diamond diamond)
    {
        currentDiamond = diamond;
        // numberOfSuccesses = 0; numberOfFailures = 0;
    }

    // helper methods
    private void SuccessFacet()
    {
        progressBarController.AddSuccess();
    }
    private void FailFacet()
    {
        progressBarController.AddFail();
    }

}
