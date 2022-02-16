using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public string itemType;
    public int healPoint;    
    [SerializeField] private ScriptableObject scriptableObject;
    public int parchment = 1;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {            

            if(itemType == "HealPoint")
            {
                PickHeal(collision);
            }
            else if(itemType == "Parchment")
            {               
                Parchment.instance.ChangeParchment(parchment);    
                gameObject.SetActive(false);

            }
        }
    }
    
    void PickHeal(Collider2D player)
    {
        player.GetComponent<PlayerLife>().addHealth(healPoint);
        gameObject.SetActive(false);
    }
    
    // void PickParchment(Collider2D player)
    // {        
        
        
    // }

}
