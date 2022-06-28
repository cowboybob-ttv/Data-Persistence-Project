using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton;

    private void Update()
    {
        if (SavedData.nameEntered)
        {
            startButton.SetActive(true);
            if (Input.GetKeyDown("space"))
            {
                StartGame();
            }
        }
    }      
    public void StartGame()
    {
        SceneManager.LoadScene(1);        
    }    
}
