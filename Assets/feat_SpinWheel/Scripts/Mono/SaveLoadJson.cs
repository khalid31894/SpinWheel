using System.IO;
using UnityEngine;

public class SaveLoadJson : MonoBehaviour
{
    public ScriptableObject scriptableObject;

    public void SaveToJson()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "data.json");
        string jsonData = JsonUtility.ToJson(scriptableObject);
        File.WriteAllText(filePath, jsonData);
        Debug.Log("Json saved at: " + filePath);  // loc: C:\Users\Apex Solution\AppData\LocalLow\DefaultCompany\SpinnWheelTemp
    }

    public void LoadFromJson()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "data.json");
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(jsonData, scriptableObject);
            Debug.Log("Json loaded from: " + filePath);
        }
        else
        {
            Debug.LogWarning("Json file not found at: " + filePath);
        }
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
        Debug.Log("OnApplicationQuit");
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveToJson();
            Debug.Log("OnApplicationFocus, !focus");
        }
    }

    private void OnApplicationPause(bool pause)
    {
        SaveToJson();
        Debug.Log("OnApplicationPause");
    }

    private void Awake()
    {
        LoadFromJson();
    }
}
