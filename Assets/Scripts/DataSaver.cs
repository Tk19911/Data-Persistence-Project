using System.IO;
using TMPro;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public static DataSaver Instance;
    public string PlayerName;
    private int HighScore;
    private string HighScorePlayerName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveHighScore(int score)
    {
        if (HighScore < score)
        {
            SaveData data = new SaveData();
            data.HighScore = score;
            data.HighScorePlayerName = PlayerName;
            Debug.Log("Save" + data.HighScore + PlayerName);
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public string LoadHighScore()
    {
        Debug.Log("Load score");
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            HighScorePlayerName = data.HighScorePlayerName;
        }

        if (string.IsNullOrEmpty(HighScorePlayerName))
        {
            return "Best Score: " + "No best score" + ": " + HighScore;
        }
        else
        {
            return "Best Score: " + HighScorePlayerName + ": " + HighScore;
        }
    }
}

[System.Serializable]
class SaveData
{
    public string HighScorePlayerName;
    public int HighScore;
}
