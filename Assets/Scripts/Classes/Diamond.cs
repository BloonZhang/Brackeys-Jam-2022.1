using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond
{
    // static counter for diamonds
    public static int IDCounter;

    public int ID;
    public float successRate;
    public float value;
    public List<bool> listOfFacets;

    private Diamond() { }

    public Diamond(float percentage)
    {
        if (IDCounter == 0) { IDCounter = 100000; }
        else { IDCounter += 1; }
        ID = IDCounter;
        successRate = percentage;
        value = 0f;
        listOfFacets = new List<bool>();
    }

    // public methods
    public string GetPercentageString()
    {
        return System.String.Format("{0:P0}", successRate);
    }
    public string GetValueString()
    {
        return System.String.Format("${0:F0}", value);
    }
    public void AddSuccess() { listOfFacets.Add(true); }
    public void AddFail() { listOfFacets.Add(false); }
    public void AddValue(float increase) { value+= increase; }
    public List<bool> GetResult() { return listOfFacets; }
}