using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStory : MonoBehaviour
{
    public GameData gd;

    void OnEnable()
    {
        gd.gameScene = "EndScreen";
        SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
    }
}
