using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Update is called once per frame

    public Animator anim;
    
    public Transform attackPoint;
    public float attackRange = 0.5f;    
    public LayerMask enemyLayers;
    public int attackDamage;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();            
        }
    }

    void Attack()
    {
        //Play an Attack Animation
        anim.SetTrigger("Attack");
        
        //Detect Enemy in Range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<EnemyLife>().TakeDamage(attackDamage);
            Debug.Log("We hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
