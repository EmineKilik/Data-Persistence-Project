using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public string bestPlayerName;
    public int bestScore;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }
    

}
