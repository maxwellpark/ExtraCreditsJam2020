using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInteraction : MonoBehaviour
{
    public GameObject playerObject;
    public PlayerData playerData;
    EnemyData enemyData; 

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerData = playerObject.GetComponent<PlayerData>();
        enemyData = GetComponent<EnemyData>(); 
    }

    void Update()
    {
        
    }

    private void DamagePlayer()
    {
        PlayerData.healthPoints -= enemyData.damage;  
    }

    public void TakeDamage(int damage)
    {
        enemyData.hitpoints -= PlayerData.damage; 
    }

    // collisions with other objects 
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGG");
        if (other.transform.tag == "Player")
        {
            DamagePlayer();
        }
        else if (other.transform.tag == "Pet")
        {
            // game over 
            // load title screen or refresh level 
            // lives? 
            Application.Quit();
        }
        else if (other.transform.tag == "Projectile")
        {
            //getcomponent<projectile>.damage 
            
            TakeDamage(CombatConstants.basicProjectileDamage);
            Destroy(other.gameObject); 

            if (enemyData.hitpoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
