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

    Vector3 lastPosition; 
    int unstickDistance; 
    
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
        Vector3 currentPosition = transform.position;

        // Remember to determine whether left or right is optimal 
        // by subtracting by adding the distance 
        if (currentPosition.x == lastPosition.x)
        {
            transform.position += new Vector3(unstickDistance, 0f, 0f);
        }
        else if (currentPosition.y == lastPosition.y)
        {
            // enemies always come from the north?
            transform.position += new Vector3(0f, -unstickDistance, 0f); 
        }

        // Save last frame's position 
        lastPosition = currentPosition;

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
                // and play animation/add static sprite 

                Destroy(other.gameObject);
                break;

            case "Wall":
                // Unstick method here?
                break; 
        }

        if (enemyData.hitpoints <= 0)
        {
            //bloodEffect.CreateBlood(); 
            Destroy(gameObject);
        }
    }

    void UnstickEnemy()
    {
        // naive solution for now 
        // can encapsulate update method here if needed. 
    }
}
