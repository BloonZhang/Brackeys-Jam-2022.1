using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond
{
    // static counter for diamonds
    public static int IDCounter;
    // static method for testing
    public static Diamond Random75Diamond()
    {
        Diamond diamond = new Diamond(0.75f);
        int facets = Random.Range(5, 16);
        for (int i = 0; i < facets; i++)
        {
            if (Random.Range(0f, 1.0f) < 0.75f) { diamond.AddSuccess(); }
            else { diamond.AddFail(); }
        }
        return diamond;
    }
    public static Diamond Random50Diamond()
    {
        Diamond diamond = new Diamond(0.5f);
        int facets = Random.Range(5, 16);
        for (int i = 0; i < facets; i++)
        {
            if (Random.Range(0f, 1.0f) < 0.5f) { diamond.AddSuccess(); }
            else { diamond.AddFail(); }
        }
        return diamond;
    }

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
    public int GetNumberOfFacets() { return listOfFacets.Count; }
    public int GetNumberOfSuccesses() 
    {
        int result = 0;
        foreach (bool facet in listOfFacets) { if (facet) { result++; } }
        return result;
    } 
}