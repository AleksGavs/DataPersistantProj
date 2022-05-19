using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class PersistantData : MonoBehaviour
{
    public static PersistantData instance;
    public InputField playerInputName;
    
    public string playerName;
    public string highestScorePlayerName;
    public int highestScore = 0;

    public void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
              
    }

    public void SetName()
    {
        playerName = playerInputName.text;
    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public string highestScorePlayerName;
        public int highestScore;
    }

    public void SaveAll()
    {
        SaveData data = new SaveData();
        data.highestScorePlayerName = highestScorePlayerName;
        data.highestScore = highestScore;
        

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadAll()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestScorePlayerName = data.highestScorePlayerName;
            highestScore = data.highestScore;
        }
    }
    public void SaveCurrentName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefilename.json", json);
    }
    public void LoadCurrentName()
    {
        string path = Application.persistentDataPath + "/savefilename.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            
        }
    }

}
