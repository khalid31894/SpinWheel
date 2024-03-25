using UnityEngine;

public class SpinWheelManager : MonoBehaviour
{
    [SerializeField] private RewardsDataDTO rewardsDataDTO;
    [SerializeField] private GameObject octantPrefab;
    [SerializeField] private Transform parent;

    private void Start()
    {
        OctantSpawner octantSpawner = new OctantSpawner(rewardsDataDTO, octantPrefab, parent);
        octantSpawner.SpawnGrid();
    }
}





[System.Serializable]
public class OctantSpawner
{
    private RewardsDataDTO rewardsDataDTO;
    private GameObject octantPrefab;
    private Transform parent;

    public OctantSpawner(RewardsDataDTO rewardsDataDTO, GameObject octantPrefab, Transform parent)
    {
        this.rewardsDataDTO = rewardsDataDTO;
        this.octantPrefab = octantPrefab;
        this.parent = parent;
    }

    public void SpawnGrid()
    {
        if (rewardsDataDTO == null || octantPrefab == null || parent == null)
        {
            Debug.LogError("Missing required components!");
            return;
        }

        HexToColorConverter converter = new HexToColorConverter();

        for (int i = 0; i < rewardsDataDTO.rewards.Count; i++)
        {
            GameObject instantiatedOctant = GameObject.Instantiate(octantPrefab, parent);

            FillOctant fillOctant_Cach = instantiatedOctant.GetComponent<FillOctant>();

            fillOctant_Cach.image.color = converter.HexToColor(rewardsDataDTO.rewards[i].color);
            fillOctant_Cach.multiplier.text = "x"+rewardsDataDTO.rewards[i].multiplier.ToString();
            fillOctant_Cach.probability = rewardsDataDTO.rewards[i].probability;

            instantiatedOctant.transform.rotation = Quaternion.Euler(0, 0, i * 45);   // ---->  anglr/octant => 2pi/8 = 45 

        }
    }
}

[System.Serializable]
public class HexToColorConverter
{
    public Color HexToColor(string hex)
    {

        hex = hex.Replace("#", "");

        float r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 255f;
        float g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber) / 255f;
        float b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) / 255f;

        Color color = new Color(r, g, b);

        return color;
    }
}

