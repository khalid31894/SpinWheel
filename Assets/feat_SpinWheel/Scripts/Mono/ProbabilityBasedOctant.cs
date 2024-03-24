using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityBasedOctant : MonoBehaviour
{
    [SerializeField] private RewardsDataDTO rewardsDataDTO;


    public static Func<int> getProbabiltyBasedOctate_Action;
    private void OnEnable()
    {
        getProbabiltyBasedOctate_Action += GetProbabilityBasedOctate;

    }
    private void OnDisable()
    {
        getProbabiltyBasedOctate_Action -= GetProbabilityBasedOctate;
    }
    private int GetProbabilityBasedOctate()
    {
        float totalProbability = 0f;

        foreach (var reward in rewardsDataDTO.rewards)
        {
            totalProbability += reward.probability;
        }

        float randomValue = UnityEngine.Random.Range(0f, totalProbability);
        float cumulativeProbability = 0f;

        for (int i = 0; i < rewardsDataDTO.rewards.Count; i++)
        {
            cumulativeProbability += rewardsDataDTO.rewards[i].probability;
            if (randomValue <= cumulativeProbability)
            {
                Debug.LogWarning("ProbabilityBasedOctate.value= " + i);

                return 7 - i;  //7 maps rewards on spin wheel => Grid octant:SO Index    0=7 1=6 2=5 3=4 ...
            }
        }

        Debug.LogWarning("Failed to select a random reward.");
        return 0;
    }




}
