using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondController : MonoBehaviour
{

    // public variables
    public Diamond currentDiamond;
    public TextMeshProUGUI percentageText;

    // private variables
    private ProgressBarController progressBarController;

    void Start()
    {
        progressBarController = JewelerSceneHandler.Instance.progressBarController;
        SetCurrentDiamond(new Diamond(0.75f));
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
    public void ForceSuccessFacet()
    {
        if (JewelerSceneHandler.Instance.ForceSuccessRemaining() <= 0) { return; }
        bool faceted = SuccessFacet();
        if (faceted) { JewelerSceneHandler.Instance.UseForceSuccess(); }
    }
    public void ForceFailFacet()
    {
        FailFacet();
    }
    public void SetCurrentDiamond(Diamond diamond)
    {
        currentDiamond = diamond;
        percentageText.text = currentDiamond.GetPercentageString();
    }
    public Diamond GetDiamond()
    {
        return currentDiamond;
    }

    // helper methods
    private bool SuccessFacet()
    {
        bool result = progressBarController.AddSuccess(); 
        if (result) { currentDiamond.AddSuccess(); }
        return result;
    }
    private bool FailFacet()
    {
        bool result = progressBarController.AddFail(); 
        if (result) { currentDiamond.AddFail(); }
        return result;
    }

}
