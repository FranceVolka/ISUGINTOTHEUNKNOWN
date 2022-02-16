using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public GameObject GameOverScreen;
    public GameObject Health;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private bool dead;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


 
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);


        //play hurt animation;        
        if(currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            //Die();
        }
        else
        {
            if(!dead)
            {
                Die();

                //Player
                GetComponent<PlayerMovement>().enabled = false;

                

                dead = true;
            }
        }
    }

    public void addHealth(int healPoint)
    {
        currentHealth += healPoint;
        healthBar.SetHealth(currentHealth);
        
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        Cursor.visible = true;     
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;   
    }

    private void GameOver()
    {
        GameOverScreen.SetActive(true);
        Health.SetActive(false);

    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
