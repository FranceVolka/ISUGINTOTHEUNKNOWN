using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator anim;
    
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;    

    

   

    // Update is called once per frame
    void Update()
    {   
       

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
            
        }       

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } 
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.GetComponent<Npc>().TriggerDialogue();       
                  
            }
            if(Input.GetKeyDown(KeyCode.F))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }
    

    public void OnLanding ()
    {
        anim.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        anim.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }
    
}
