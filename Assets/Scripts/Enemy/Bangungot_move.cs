using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bangungot_move : MonoBehaviour
{

    public float speed;
    public bool moveRight;

    // Update is called once per frame
    void Update()
    {
        //if move to right true will always move right
        if(moveRight)
        {            
            transform.Translate(2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2 (1,1);
        }   
        else
        {        
            transform.Translate(-2 * Time.deltaTime * speed , 0,0);
            transform.localScale = new Vector2 (-1,1);
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("turn"))
        {
            if(moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }
}
