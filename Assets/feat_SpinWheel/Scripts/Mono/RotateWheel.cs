using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    [SerializeField] RewardsDataDTO rewardsDataDTO;
    public static Action<int,float,float> rotate_Action;

    public float randomTime;
   public  float timer;
    public int itemNumber;
    public float anglePerItem;
    public bool isSpinning;


    public List< AnimationCurve > animationCurves;





    Coroutine coroutine;


    private void Awake()
    {
        anglePerItem = (float)360 /(float) rewardsDataDTO.rewards.Length;
    }
    private void OnEnable()
    {
        rotate_Action += Rotate;
    }
    private void OnDisable()
    {
        rotate_Action -= Rotate;
    }

    private void Rotate(int result, float rot, float t)
    {
        randomTime = 15;
        timer = 0.0f;
        for(int i = 0; i <rewardsDataDTO.rewards.Length; i++)
        {
            if (rewardsDataDTO.rewards[i].multiplier == result)
            {
                itemNumber = i; break;
            }

        }
        float maxAngle = 360 * randomTime - (itemNumber * anglePerItem) + rot;
        coroutine = StartCoroutine(RotateCor(t,maxAngle));

    }

    IEnumerator RotateCor(float time , float maxAngle)
    {
        isSpinning = true;
        float startAngle = transform.eulerAngles.z;
        maxAngle -= startAngle;
            int animationCurveNumber= UnityEngine.Random.Range(0, animationCurves.Count);
        
        while (timer<time)
        {
            float angle = maxAngle * animationCurves[animationCurveNumber].Evaluate(timer / time);
            transform.eulerAngles = -new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle + startAngle );
            timer += Time.deltaTime;
            yield return 0;
        }

        transform.eulerAngles = -new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxAngle + startAngle);
        isSpinning= false;

        
    }
}
