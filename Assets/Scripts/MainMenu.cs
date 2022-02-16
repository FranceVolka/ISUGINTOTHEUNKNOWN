using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        gd.gameScene = "MenuScreen";
    }
    public GameData gd;
    public void NewGame()
    {
        
        SceneManager.LoadScene("MainStory");       
    }
    public void ExitToMenu()
    {        
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
