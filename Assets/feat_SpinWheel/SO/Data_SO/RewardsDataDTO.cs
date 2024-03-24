
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RewardsDataDTO :ScriptableObject
{
    public int coins;
    //public RewardDTO[] rewards;
    public List<RewardDTO> rewards;
}

[Serializable]
public class RewardDTO
{
    public int multiplier;
    public float probability;
    public string color;
}

