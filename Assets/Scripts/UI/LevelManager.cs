using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;

public class LevelManager : MonoBehaviour
{

    public Animator transition;

    public float transitionTime;
    public GameData gd;
    public void LoadNextLevel ()
    {
        gd.gameScene = "Level1";
        StartCoroutine(LoadLevel("Level1"));
    }
    IEnumerator LoadLevel (string nextLevel)
    {
       transition.SetTrigger("Start");

       yield return new WaitForSeconds(transitionTime);

       
       SceneManager.LoadScene(nextLevel);
    }
}
