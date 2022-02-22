using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond
{
    // static counter for diamonds
    public static int IDCounter;

    public int ID;
    public float successRate;

    private Diamond() { }

    public Diamond(float percentage)
    {
        if (IDCounter == 0) { IDCounter = 100000; }
        else { IDCounter += 1; }
        successRate = percentage;
    }

    public string GetPercentageString()
    {
        return System.String.Format("{0:P0}", successRate);
    }
}
