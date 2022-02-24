using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiamondController : MonoBehaviour
{
    // settings
    public int minTries = 5;
    public int maxTries = 15;

    // public GameObjects
    public Transform gridLayout;
    public GameObject successPrefab;
    public GameObject failPrefab;
    public Button swapButton;
    public Button finishButton;
    public TextMeshProUGUI currentValueText;
    public TextMeshProUGUI nextFacetText;

    // public variables
    public Diamond currentDiamond;
    public TextMeshProUGUI percentageText;

    // private variables
    private int numberOfFacets = 0;

    void Start()
    {
        SetCurrentDiamond(new Diamond(0.75f));
        finishButton.interactable = false;
    }

    // faceting methods
    public void TryFacetDiamond()
    {
        // If 100% success rate
        if (currentDiamond.successRate == 1.0f) { FacetDiamond(true); }
        // Otherwise, generate random number
        float randomValue = Random.value;
        if (randomValue < currentDiamond.successRate) { FacetDiamond(true); }
        else { FacetDiamond(false); }
    }
    public void ForceSuccessFacet()
    {
        if (JewelerSceneHandler.Instance.ForceSuccessRemaining() <= 0) { return; }
        bool faceted = FacetDiamond(true);
        if (faceted) { JewelerSceneHandler.Instance.UseForceSuccess(); }
    }
    public void ForceFailFacet()
    {
        FacetDiamond(false);
    }
    private bool FacetDiamond(bool successful)
    {
        // Check if we've met the max number of tries
        if (numberOfFacets >= maxTries) { return false; }
        // If not, let's proceed with faceting
        numberOfFacets++;
        // Success
        if (successful) 
        {
            Instantiate(successPrefab, gridLayout);
            currentDiamond.AddSuccess();
        }
        // fail
        else
        {
            Instantiate(failPrefab, gridLayout);
            currentDiamond.AddFail();
        }
        // Turn off swap button, since we've faceted the diamond now
        swapButton.interactable = false;
        // Turn on finish button if met minimun tries
        if (numberOfFacets >= minTries) { finishButton.interactable = true; }
        return true;
    }
    // data methods
    public void SetCurrentDiamond(Diamond diamond)
    {
        currentDiamond = diamond;
        numberOfFacets = 0;
        percentageText.text = currentDiamond.GetPercentageString();
        UpdateValueText();
    }
    public Diamond GetDiamond()
    {
        return currentDiamond;
    }

    // helper methods
    private void UpdateValueText() { currentValueText.text = currentDiamond.GetValueString(); }
}
