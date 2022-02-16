using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    private bool quickSaveAvailable, checkSlot1, checkSlot2;

    private const string slot1 = "Slot 1 | ";
    private const string slot2 = "Slot 2 | ";
    private const string quicksave = "Quick Save | ";
    private const string lastSaved = "LAST SAVED: ";

    public TextMeshProUGUI slot_1, slot_2, slot_qs;
    public TextMeshProUGUI slot_1_time, slot_2_time, slot_qs_time;
    private bool isSlot1, isSlot2, isQuickSave;

    public GameData gd;

    public List<GameObject> deleteBtn;
    private void Start()
    {
        GetStoredSaves();
    }

    public void HardReset()
    {
        PlayerPrefs.DeleteAll();
        GetStoredSaves();
    }
    public void InGame_OpenSaveScreen()
    {
        GetStoredSaves();
    }
    private void GetStoredSaves()
    {
        if (PlayerPrefs.HasKey("date_qs"))
        {
            slot_qs.SetText(quicksave + PlayerPrefs.GetString("scene_qs"));
            slot_qs_time.SetText(lastSaved
                + PlayerPrefs.GetString("date_qs") + " "
                + PlayerPrefs.GetString("day_qs") + " "
                + PlayerPrefs.GetString("time_qs"));

            slot_qs.gameObject.transform.parent.gameObject.GetComponent<Button>().interactable = true;
            if (gd.gameScene == "MenuScreen")
                deleteBtn[2].SetActive(true);
        }
        else {

            slot_qs.SetText(quicksave + "Empty");
            slot_qs_time.SetText(lastSaved + "- - -");
           
            slot_qs.gameObject.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.HasKey("date_s1"))
        {
            slot_1.SetText(slot1 + PlayerPrefs.GetString("scene_s1"));
            slot_1_time.SetText(lastSaved
                + PlayerPrefs.GetString("date_s1") + " "
                + PlayerPrefs.GetString("day_s1") + " "
                + PlayerPrefs.GetString("time_s1"));

            slot_1.gameObject.transform.parent.gameObject.GetComponent<Button>().interactable = true;
            if (gd.gameScene == "MenuScreen")
                deleteBtn[0].SetActive(true);
        }
        else
        {
            slot_1.SetText(slot1 + "Empty");
            slot_1_time.SetText(lastSaved + "- - -");
            slot_1.gameObject.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.HasKey("date_s2"))
        {
            slot_2.SetText(slot2 + PlayerPrefs.GetString("scene_s2"));
            slot_2_time.SetText(lastSaved
                + PlayerPrefs.GetString("date_s2") + " "
                + PlayerPrefs.GetString("day_s2") + " "
                + PlayerPrefs.GetString("time_s2"));

            slot_2.gameObject.transform.parent.gameObject.GetComponent<Button>().interactable = true;
            if (gd.gameScene == "MenuScreen")
                deleteBtn[1].SetActive(true);
        }
        else
        {
            slot_2.SetText(slot2 + "Empty");
            slot_2_time.SetText(lastSaved + "- - -");
            slot_2.gameObject.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        }

        if (gd.gameScene != "MenuScreen")
        {
            slot_qs.gameObject.transform.parent.gameObject.GetComponent<Button>().interactable = true;
            slot_1.gameObject.transform.parent.gameObject.GetComponent<Button>().interactable = true;
            slot_2.gameObject.transform.parent.gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void LoadGame(string savedFile)
    {
        StartCoroutine(loadThis(savedFile));
    }

    IEnumerator loadThis(string savedFile)
    {
        string sceneName = "";
        Vector3 loadedPos = new Vector3(0, 0, 0);
        switch (savedFile)
        {
            case "save1":
                sceneName = PlayerPrefs.GetString("scene_s1");
                loadedPos.x = PlayerPrefs.GetFloat("playerX_s1");
                loadedPos.y = PlayerPrefs.GetFloat("playerY_s1");
                loadedPos.z = PlayerPrefs.GetFloat("playerZ_s1");
                break;
            case "save2":
                sceneName = PlayerPrefs.GetString("scene_s2");
                loadedPos.x = PlayerPrefs.GetFloat("playerX_s2");
                loadedPos.y = PlayerPrefs.GetFloat("playerY_s2");
                loadedPos.z = PlayerPrefs.GetFloat("playerZ_s2");
                break;
            case "quicksave":
                sceneName = PlayerPrefs.GetString("scene_qs");
                loadedPos.x = PlayerPrefs.GetFloat("playerX_qs");
                loadedPos.y = PlayerPrefs.GetFloat("playerY_qs");
                loadedPos.z = PlayerPrefs.GetFloat("playerZ_qs");
                break;
        }
        SceneManager.LoadSceneAsync(sceneName);

        gd.playerPosition = loadedPos;
        gd.isLoading = true;

        yield return null;

        gd.gameScene = sceneName;
        yield return new WaitForFixedUpdate();
        SceneManager.UnloadSceneAsync("Menu");
    }
    
    public void NewGame()
    {
        gd.gameScene = "Level 1";
        SceneManager.LoadScene("IsugScene");
    }

    public void DeleteSave1()
    {
        PlayerPrefs.DeleteKey("playerX_s1");
        PlayerPrefs.DeleteKey("playerY_s1");
        PlayerPrefs.DeleteKey("playerZ_s1");
        PlayerPrefs.DeleteKey("date_s1");
        PlayerPrefs.DeleteKey("day_s1");
        PlayerPrefs.DeleteKey("time_s1");
        PlayerPrefs.DeleteKey("scene_s1");
        PlayerPrefs.DeleteKey("_s1");
        PlayerPrefs.DeleteKey("_s1");

        GetStoredSaves();
    }

    public void DeleteSave2()
    {
        PlayerPrefs.DeleteKey("playerX_s2");
        PlayerPrefs.DeleteKey("playerY_s2");
        PlayerPrefs.DeleteKey("playerZ_s2");
        PlayerPrefs.DeleteKey("date_s2");
        PlayerPrefs.DeleteKey("day_s2");
        PlayerPrefs.DeleteKey("time_s2");
        PlayerPrefs.DeleteKey("scene_s2");
        PlayerPrefs.DeleteKey("_s2");
        PlayerPrefs.DeleteKey("_s2");

        GetStoredSaves();

    }

    public void DeleteQuickSave()
    {
        PlayerPrefs.DeleteKey("playerX_qs");
        PlayerPrefs.DeleteKey("playerY_qs");
        PlayerPrefs.DeleteKey("playerZ_qs");
        PlayerPrefs.DeleteKey("date_qs");
        PlayerPrefs.DeleteKey("day_qs");
        PlayerPrefs.DeleteKey("time_qs");
        PlayerPrefs.DeleteKey("scene_qs");
        PlayerPrefs.DeleteKey("_qs");
        PlayerPrefs.DeleteKey("_qs");

        GetStoredSaves();

    }
}
