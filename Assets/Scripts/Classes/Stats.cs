using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{
    // n choose k
    public static int nCk(int n, int k)
    {
        int result = 1;
        for (int i = 1; i <= k; i++)
        {
            result *= n - (k - i);
            result /= i;
        }
        return result;
    }

    // probability of k successes in n trials
    public static float CalculateProbability(int n, int k, float p)
    {
        float nck = (float) Stats.nCk(n, k);
        return nck * Mathf.Pow(p, (float)k) * Mathf.Pow((1- p), (float)(n-k));
    }

}
