using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavedData : MonoBehaviour
{
    public static string playerName;
    public static string nameHighScores;
    public static SavedData Instance;
    public static bool nameEntered = false;
    public static int highScores;
    public static string SavePath;    

    private void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    [System.Serializable]
    class LeadingPlayer
    {
        public string NameHighScore;
        public int HighScore;
    }    

    public static void SaveNamePlusScore()
    {
        LeadingPlayer data = new LeadingPlayer();
        data.NameHighScore = nameHighScores;
        data.HighScore = highScores;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);     
    }

    public static void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            LeadingPlayer data = JsonUtility.FromJson<LeadingPlayer>(json);

            nameHighScores = data.NameHighScore;
            highScores = data.HighScore;
        }
        
    }

    public static void PlayerName(string s)
    {
        playerName = s;
        nameEntered = true;
        Debug.Log(playerName);
    }
}
