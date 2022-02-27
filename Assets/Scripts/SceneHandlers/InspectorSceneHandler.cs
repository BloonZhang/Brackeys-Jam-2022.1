using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InspectorSceneHandler : MonoBehaviour
{
    //////// Singleton shenanigans ////////
    private static InspectorSceneHandler _instance;
    public static InspectorSceneHandler Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    // public GameObjects
    public GraphController graphController;
    public TextMeshProUGUI facetsText;
    public TextMeshProUGUI successesText;
    public TextMeshProUGUI probabilityExactText;
    public TextMeshProUGUI probabilityAtLeastText;

    // private variables
    private Diamond currentDiamond;

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

    void Start()
    {
        // /* placeholder line
        ReceieveRandomDiamond();
        // */ placeholder line 
    }

    // testing method
    public void ReceieveRandomDiamond() { ReceiveDiamond(Diamond.Random75Diamond()); }

    // public methods
    public void ReceiveDiamond(Diamond diamond)
    {
        // Update relevant variables
        currentDiamond = diamond; 
        graphController.numberOfFacets = currentDiamond.GetNumberOfFacets();
        graphController.numberOfSuccesses = currentDiamond.GetNumberOfSuccesses();
        // Draw graph
        graphController.DrawEVGraph(0.75f);
        UpdateAllText();
    }

    // helper methods
    public void UpdateAllText()
    {
        facetsText.text = graphController.numberOfFacets.ToString();
        successesText.text = graphController.numberOfSuccesses.ToString();
        probabilityExactText.text = 
            System.String.Format("{0:P1}", 
                                Stats.CalculateProbability(graphController.numberOfFacets, 
                                                            graphController.numberOfSuccesses, 
                                                            graphController.currentProbabilityShown));
        probabilityAtLeastText.text = 
            System.String.Format("{0:P1}", 
                                  Stats.CalculateCumulativeProbability(graphController.numberOfFacets, 
                                                                      graphController.numberOfSuccesses, 
                                                                      graphController.currentProbabilityShown));
    }
}
