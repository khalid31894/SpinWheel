using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    [SerializeField] RewardsDataDTO rewardsDataDTO;

    public static Action<int, float, float, bool, AnimationCurve> rotate_Action;

    private float anglePerOctant;
    private bool isSpinning;
    private Coroutine rotationCoroutine;

    private void Awake()
    {
        anglePerOctant = 360f / rewardsDataDTO.rewards.Count;
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
        

        if (!isSpinning)
        {
            float maxAngle = revolutions * 360f + desiredOctant * anglePerOctant;
            rotationCoroutine = StartCoroutine(RotateCor(spinTime, maxAngle, isClockwise, curve));
        }
    }

    private IEnumerator RotateCor(float spinTime, float maxAngle, bool isClockwise, AnimationCurve curve)
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
            yield return null;
        }

        float endAngle = startAngle + (isClockwise ? maxAngle : -maxAngle);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, endAngle);

        isSpinning = false;
        


    }
}
