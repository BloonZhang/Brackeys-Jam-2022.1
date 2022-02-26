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
    private float nextFacetValue = 0f;

    void Start()
    {
        // /* placeholder line
        SetCurrentDiamond(new Diamond(0.75f));
        // */ placeholder line
        Reset();
    }

    // faceting methods
    public void TryFacetDiamond()
    {
        // Check if we've met the max number of tries
        if (numberOfFacets >= maxTries) { return; }
        // Increase value of diamond for natural facet
        AddValueToDiamond(nextFacetValue);
        // If 100% success rate
        if (currentDiamond.successRate == 1.0f) { FacetDiamond(true); }
        // Otherwise, generate random number
        float randomValue = Random.value;
        if (randomValue < currentDiamond.successRate) { FacetDiamond(true); }
        else { FacetDiamond(false); }
    }
    public void ForceSuccessFacet()
    {
        if (numberOfFacets >= maxTries) { return; }
        if (JewelerSceneHandler.Instance.ForceSuccessRemaining() <= 0) { return; }
        FacetDiamond(true);
        JewelerSceneHandler.Instance.UseForceSuccess();
    }
    public void ForceFailFacet()
    {
        if (numberOfFacets >= maxTries) { return; }
        FacetDiamond(false);
    }
    private void FacetDiamond(bool successful)
    {
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
        // Calculate value of next facet given the parameters
        CalculateNextFacetValue();
        // Turn off swap button, since we've faceted the diamond now
        swapButton.interactable = false;
        // Turn on finish button if met minimun tries
        if (numberOfFacets >= minTries) { finishButton.interactable = true; }
    }
    // diamond methods
    public void SetCurrentDiamond(Diamond diamond)
    {
        currentDiamond = diamond;
        numberOfFacets = 0;
        percentageText.text = currentDiamond.GetPercentageString();
        nextFacetValue = 100f / Stats.CalculateRisk(numberOfFacets + 1, 0.75f, currentDiamond.successRate);
        UpdateAllText();
    }
    public Diamond GetDiamond() { return currentDiamond; }
    public void AddValueToDiamond(float increase) { currentDiamond.AddValue(increase); UpdateValueText(); }

    // helper methods
    private void CalculateNextFacetValue()
    {
        // for now, no real formula
        nextFacetValue += 50f / Stats.CalculateRisk(numberOfFacets + 1, 0.75f, currentDiamond.successRate);
        UpdateNextFacetText();
    }
    private void UpdateAllText() { UpdateValueText(); UpdateNextFacetText(); }
    private void UpdateValueText() { currentValueText.text = currentDiamond.GetValueString(); }
    private void UpdateNextFacetText() { nextFacetText.text = System.String.Format("${0:F0}", nextFacetValue); }
    private void Reset()
    {
        finishButton.interactable = false;
        UpdateAllText();
    }
}
