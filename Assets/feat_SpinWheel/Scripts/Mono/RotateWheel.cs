using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    [SerializeField] RewardsDataDTO rewardsDataDTO;
    public static Action<int,float, float> rotate_Action;

    public List<AnimationCurve> animationCurves;


    private float timer;
    private float anglePerOctant;
    private bool isSpinning;



    private void Awake()
    {
        anglePerOctant = (float)360 / (float)rewardsDataDTO.rewards.Count;
    }
    private void OnEnable()
    {
        rotate_Action += Rotate;
    }
    private void OnDisable()
    {
        rotate_Action -= Rotate;
    }

    private void Rotate(int desiredOctant, float spinTime, float revolutions)
    {
        timer = 0.0f;
      
        float maxAngle = 360 * revolutions - (desiredOctant * anglePerOctant);
        if (!isSpinning) 
        { 
            StartCoroutine(RotateCor(spinTime, maxAngle));
        }

    }

    IEnumerator RotateCor(float spinTime, float maxAngle)
    {
        isSpinning = true;
        float startAngle = transform.eulerAngles.z;
        maxAngle -= startAngle;
        int animationCurveIndex = UnityEngine.Random.Range(0, animationCurves.Count);

        while (timer < spinTime)
        {
            float angle = maxAngle * animationCurves[animationCurveIndex].Evaluate(timer / spinTime);
            transform.eulerAngles = -new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle + startAngle);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = -new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxAngle + startAngle);
        isSpinning = false;


    }
}
