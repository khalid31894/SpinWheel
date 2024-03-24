using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class DisplayMultiplier : MonoBehaviour
{
    TextMeshProUGUI multiplierTxt;

    [SerializeField] private RewardAndMultiplier_SO rewardAndMultiplier_SO;


    private void Start()
    {
        multiplierTxt = GetComponent<TextMeshProUGUI>();

        multiplierTxt.text = ("x" + rewardAndMultiplier_SO.multiplier.ToString());

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

        multiplierTxt.text = ("x" + rewardAndMultiplier_SO.multiplier);
    }
}
