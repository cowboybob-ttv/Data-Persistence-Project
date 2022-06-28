using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static string playerName;
    public static bool nameEntered = false;
    public static GameObject startButton;   
    public void StartGame()
    {
        if (nameEntered)
        {
        SceneManager.LoadScene(1);
        }
    }

    public static void PlayerName(string s)
    {
        playerName = s;
        nameEntered = true;
        Debug.Log(playerName);
        startButton.SetActive(true);
    }
}
