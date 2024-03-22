using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWheelManager : MonoBehaviour
{
    [SerializeField] RewardsDataDTO rewardsDataDTO;

    [SerializeField] GameObject octant;
    [SerializeField] Transform parent;
    private void SpawnGrid()
    {
        for (int i = 0; i < rewardsDataDTO.rewards.Length; i++) 
        {
          GameObject instantiated_Octant =  Instantiate(octant, parent);
          instantiated_Octant.transform.rotation = Quaternion.Euler(0, 0, i * 45);   // pi/8=22.5   delta=> 22.5*2 = 45 degree

        }
    }
    private void Start()
    {
        SpawnGrid();
    }
}
