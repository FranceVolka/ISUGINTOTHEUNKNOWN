using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    public GameData gd;

    void OnEnable()
    {
        gd.gameScene = "Level1";
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
