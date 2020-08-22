using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    float attackCooldown = 10f;
    float attackTimer; 
    float attackRange;
    int damage; 

    public Transform attackPosition;
    public LayerMask nearbyEnemies; 


    void Start()
    {
        
    }

    void Update()
    {
        if (attackTimer <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] affectedEnemies = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, nearbyEnemies);
                foreach(Collider2D affectedEnemy in affectedEnemies)
                {
                    affectedEnemy.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            attackTimer = attackCooldown;
        }

        else
        {
            attackTimer -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange); 
    }
}
