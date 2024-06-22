using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public static string Name = ""; // Player name
    public static int HighScore;

    // Create data manager on awake
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int HighScore;
    }

    public void SaveInfo()
    {
        SaveData data = new();
        data.Name = Name;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            HighScore = data.HighScore;
        }
    }
}
