using System;
using System.Collections;

using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    [SerializeField] private RewardsDataDTO rewardsDataDTO;
    [SerializeField] private RewardAndMultiplier_SO rewardAndMultiplier_SO;

    private UpdateUIs updateUIs;

    public static Action<int, float, float, bool, AnimationCurve> rotate_Action;

    public static event Action OnSpinWheelComplete;

    private float anglePerOctant;
    private bool isSpinning;
    private Coroutine rotationCoroutine;

    private void Awake()
    {
        anglePerOctant = 360f / rewardsDataDTO.rewards.Count;

        updateUIs = new UpdateUIs(rewardsDataDTO, rewardAndMultiplier_SO);

    }

    private void OnEnable()
    {
        rotate_Action += Rotate;
    }

    private void OnDisable()
    {
        rotate_Action -= Rotate;
    }

    private void Rotate(int desiredOctant, float spinTime, float revolutions, bool isClockwise, AnimationCurve curve)
    {
        transform.eulerAngles = new Vector3(0,0,0); //Fresh Start on every spin

        desiredOctant= isClockwise? desiredOctant: 8 - desiredOctant; //for anit clockwise

        if (!isSpinning)
        {
            float maxAngle = revolutions * 360f + desiredOctant * anglePerOctant;
            rotationCoroutine = StartCoroutine(RotateCor(desiredOctant, spinTime, maxAngle, isClockwise, curve));
        }
    }

    private IEnumerator RotateCor(int desiredOctant, float spinTime, float maxAngle, bool isClockwise, AnimationCurve curve)
    {
        isSpinning = true;
        float startAngle = transform.eulerAngles.z;

        float timer = 0f;
        while (timer < spinTime)
        {
            float angle = maxAngle * curve.Evaluate(timer / spinTime);
            float currentAngle = startAngle + (isClockwise ? angle : -angle);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentAngle);
            timer += Time.deltaTime;
            yield return null;  //on yiled give control back to unity for smoother process
        }

        float endAngle = startAngle + (isClockwise ? maxAngle : -maxAngle);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, endAngle);

        isSpinning = false;

        OnComplete(desiredOctant);

    }

    private void OnComplete(int desiredOctant)
    {
        updateUIs.Update_rewardMultiplier_SO(desiredOctant);
        OnSpinWheelComplete?.Invoke();
    }


}

[System.Serializable]
public class UpdateUIs
{

    private RewardsDataDTO rewardsDataDTO;
    private RewardAndMultiplier_SO rewardMultiplier_SO;
    public UpdateUIs(RewardsDataDTO rewardsDataDTO, RewardAndMultiplier_SO rewardMultiplier_SO)
    {
        this.rewardsDataDTO = rewardsDataDTO;
        this.rewardMultiplier_SO = rewardMultiplier_SO;
    }

    public void Update_rewardMultiplier_SO(int finalOctate)
    {
        rewardMultiplier_SO.multiplier = rewardsDataDTO.rewards[7 - finalOctate].multiplier;
        rewardMultiplier_SO.TotalScore += (rewardsDataDTO.rewards[7 - finalOctate].multiplier * rewardMultiplier_SO.TotalScore);

    }

}

