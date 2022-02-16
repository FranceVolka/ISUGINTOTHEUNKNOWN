using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public Transform player;
    private Vector3 startPositionLevel1 = new Vector3(-23.41f, -3f, -12.35596f);
    public GameData gd;
    public bool isSaving;
    public GameObject UI_display;
    public GameObject Library_display;
    private void Start()
    {
        if (gd.isLoading == true)
        {
            gd.isLoading = false;
            player.position = gd.playerPosition;
        }
    }

    private void OnApplicationQuit()
    {
        QuickSave();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UI_display.activeInHierarchy)
            {

                UI_display.SetActive(false);
            }
            else
            {
                UI_display.SetActive(true);
                
            }

        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            if (Library_display.activeInHierarchy)
            {
                Library_display.SetActive(false);
            }
            else
            {
                Library_display.SetActive(true);
            }
        }
    }

    public void BackToMenu()
    {
        QuickSave();
        SceneManager.LoadScene("Menu");
    }
    

    public void QuickSave()
    {
        if (gd.gameScene != "MenuScreen")
        {
            Vector3 playerPos = player.position;
            PlayerPrefs.SetFloat("playerX_qs", playerPos.x);
            PlayerPrefs.SetFloat("playerY_qs", playerPos.y);
            PlayerPrefs.SetFloat("playerZ_qs", playerPos.z);

            PlayerPrefs.SetString("date_qs", GetCurrentDate_DDMMMYYY());
            PlayerPrefs.SetString("day_qs", GetCurrentDayName());
            PlayerPrefs.SetString("time_qs", GetCurrentTime());

            PlayerPrefs.SetString("scene_qs", gd.gameScene);
        }
    }

    public void Save1()
    {
        Vector3 playerPos = player.position;
        PlayerPrefs.SetFloat("playerX_s1", playerPos.x);
        PlayerPrefs.SetFloat("playerY_s1", playerPos.y);
        PlayerPrefs.SetFloat("playerZ_s1", playerPos.z);

        PlayerPrefs.SetString("date_s1", GetCurrentDate_DDMMMYYY());
        PlayerPrefs.SetString("day_s1", GetCurrentDayName());
        PlayerPrefs.SetString("time_s1", GetCurrentTime());

        PlayerPrefs.SetString("scene_s1", gd.gameScene);
    }

    public void Save2()
    {
        Vector3 playerPos = player.position;
        PlayerPrefs.SetFloat("playerX_s2", playerPos.x);
        PlayerPrefs.SetFloat("playerY_s2", playerPos.y);
        PlayerPrefs.SetFloat("playerZ_s2", playerPos.z);

        PlayerPrefs.SetString("date_s2", GetCurrentDate_DDMMMYYY());
        PlayerPrefs.SetString("day_s2", GetCurrentDayName());
        PlayerPrefs.SetString("time_s2", GetCurrentTime());

        PlayerPrefs.SetString("scene_s2", gd.gameScene);
    }

    public void OnClick_Reset()
    {
        player.position = startPositionLevel1;
        
    }


    public string GetCurrentDate_DDMMMYYY()
    {
        return DateTime.Now.GetDateTimeFormats()[1];
    }
    public string GetCurrentDayName()
    {
        return DateTime.Now.DayOfWeek.ToString();
    }
    public string GetCurrentTime()
    {
        return DateTime.Now.ToString("HH:mm");
    }

}
