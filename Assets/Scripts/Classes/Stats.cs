using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{
    // n choose k
    public static long nCk(int n, int k)
    {
        long result = 1;
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

    // some weird form of risk calculation
    // I think this calculates the probability that a value from p1 will reasonably be from p2?
    // Given n trials, plot the binomial distribution of p1 and p2, and find area under both
    public static float CalculateRisk(int n, float p1, float p2)
    {
        float result = 0.0f;
        for (int i = 0; i <= n; i++)
        {
            result += Mathf.Min(CalculateProbability(n, i, p1), CalculateProbability(n, i, p2));
        }
        return result;
    }

}
