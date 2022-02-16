using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject transition;
    // private bool playerInRange;


    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.E) && playerInRange)
    //     {
    //         TriggerDialogue();
    //     }
    // }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transition.SetActive(true);
            Debug.Log("Player In Range");            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transition.SetActive(false);
            Debug.Log("Player Not In Range");            
        }
    }
}
