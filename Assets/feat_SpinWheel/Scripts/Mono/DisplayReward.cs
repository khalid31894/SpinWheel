using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class DisplayReward : MonoBehaviour, IUpdateUi
{
    TextMeshProUGUI rewardTxt;
    [SerializeField] private RewardsDataDTO rewardsDataDTO;
    [SerializeField] private RewardAndMultiplier_SO rewardAndMultiplier_SO;
    private void Start()
    {
        rewardAndMultiplier_SO.TotalScore= rewardsDataDTO.coins; // Set Once becuse its already provided in Jason 300
        
        rewardTxt=GetComponent<TextMeshProUGUI>();
        rewardTxt.text =("<sprite=12>"+ PostFixGenerator.AddPostfix(rewardsDataDTO.coins));


    }


    private void OnEnable()
    {
        RotateWheel.OnSpinWheelComplete += UpdateUi;
    }
    private void OnDisable()
    {
        RotateWheel.OnSpinWheelComplete -= UpdateUi;

    }

    public void UpdateUi()
    {

        rewardTxt.text = ("<sprite=12>" + PostFixGenerator.AddPostfix(rewardAndMultiplier_SO.TotalScore));
    }
}
