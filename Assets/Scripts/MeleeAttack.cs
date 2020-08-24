using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject meleeWeapon; 
    public GameObject visualPrefab; 
    GameObject currentVisual;
    public Transform attackPosition;
    public LayerMask nearbyEnemies;

    public float attackRange;
    float attackCooldown = 10f;
    float attackTimer = 0f; 
    float visualTimer; 
    bool isShowing; 

    int damage = 1;




    void Start()
    {
        
    }

    void Update()
    {
        if (attackTimer <= 0)
        {
            if (Input.GetKeyUp("space"))
            {
                Debug.Log("Spacebar"); 
                WeaponVisual(); 

                Collider2D[] affectedEnemies = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, nearbyEnemies);
                foreach(Collider2D affectedEnemy in affectedEnemies)
                {
                    affectedEnemy.GetComponent<EnemyInteraction>().TakeDamage(damage);
                }
            }
            attackTimer = attackCooldown;
        }

        else
        {
            attackTimer -= Time.deltaTime;
        }

        if (visualTimer <= 0 && isShowing)
        {
            Destroy(currentVisual);
            isShowing = false;
        }
        else
        {
            visualTimer -= Time.deltaTime;
        }


    }

    private void WeaponVisual()
    {
        currentVisual = Instantiate(visualPrefab);
        currentVisual.transform.parent = meleeWeapon.transform;
        isShowing = true;
        visualTimer = 3f;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange); 
    }
}
