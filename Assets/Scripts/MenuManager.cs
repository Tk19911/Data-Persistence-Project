#if UNITY_EDITOR
using System.Web;
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nameInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {     
    }

    public void SavePlayerName()
    {
        if (!string.IsNullOrWhiteSpace(nameInput.text))
        {
            Debug.Log(nameInput.text);
            DataSaver.Instance.PlayerName = nameInput.text;
            Debug.Log(DataSaver.Instance.PlayerName);
        }
        else
        {
            DataSaver.Instance.PlayerName = "No Name Entered";
        }

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
