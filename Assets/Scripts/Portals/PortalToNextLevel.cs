using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  
public class PortalToNextLevel : MonoBehaviour
{
    public UIButtons uibtns;
    public GameObject trapdoor;
    public GameData gd;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Portal1")
        {
            if (gd.gameScene == "Level1")
            {
                gd.gameScene = "Level2";
            }
            SceneManager.LoadScene(gd.gameScene);
        }
        else if (other.gameObject.tag == "Portal2")
        {
            if (gd.gameScene == "Level2")
            {
                gd.gameScene = "Level3";
            }
            SceneManager.LoadScene(gd.gameScene);
        }
        else if (other.gameObject.tag == "Portal3")
        {
            if (gd.gameScene == "Level3")
            {
                gd.gameScene = "EndStory";
            }
            SceneManager.LoadScene(gd.gameScene);
        }
        else if (other.gameObject.tag == "Block")
        {
            Vector3 playerPos = gameObject.transform.position;
            playerPos.x += 0.2f;
            gameObject.transform.position = playerPos;
            //uibtns.OnClick_Reset();
        }
        else if (other.gameObject.tag == "TriggerDoor")
        {
            StartCoroutine(delayTrapDoor());
        }
        else if (other.gameObject.tag == "TriggerDoor" && other.gameObject.name == "ShrineOpen")
        {
            GameObject shrine = other.gameObject.transform.parent.gameObject;
            StartCoroutine(delayShrineDoor(shrine));
        }
        else if (other.gameObject.tag == "Bouncy")
        {
            Vector3 playerPos = gameObject.transform.position;
            playerPos.y += 0.2f;
            gameObject.transform.position = playerPos;
            StartCoroutine(lowerGravity());
        }
        
    }

    IEnumerator lowerGravity()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 2f;
    }

    IEnumerator delayTrapDoor()
    {
        trapdoor.SetActive(false);
        yield return new WaitForSeconds(2);
        trapdoor.SetActive(true);
    }

    IEnumerator delayShrineDoor(GameObject shrine)
    {
        shrine.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2);
        shrine.GetComponent<Collider2D>().enabled = true;
    }
}
