using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyInteraction : MonoBehaviour
{
    public GameObject playerObject;
    public PlayerData playerData;
    EnemyData enemyData;
    
    //BloodEffect bloodEffect;
    //public GameObject blood; 

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerData = playerObject.GetComponent<PlayerData>();
        enemyData = GetComponent<EnemyData>();
        //bloodEffect = GetComponent<BloodEffect>(); 
    }

    void Update()
    {
        
    }

    public void TakeDamage()
    {
        enemyData.hitpoints -= PlayerData.damage;
        // enemy hit effect here 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.transform.tag)
        {
            case "Pet":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;

            case "Projectile":
                TakeDamage();
                Destroy(other.gameObject);
                break;

            case "SlowProjectile":
                TakeDamage();
                enemyData.movementSpeed -= PlayerData.slowAmount;
                Destroy(other.gameObject);
                break;

            case "SnareProjectile":
                TakeDamage();
                enemyData.movementSpeed = 0f;
                // remember to start timer

                Destroy(other.gameObject);
                break;
        }

        if (enemyData.hitpoints <= 0)
        {
            //bloodEffect.CreateBlood(); 
            Destroy(gameObject);
        }
    }
}
