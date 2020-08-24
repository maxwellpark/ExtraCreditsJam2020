using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInteraction : MonoBehaviour
{
    public GameObject playerObject;
    public PlayerData playerData;
    EnemyData enemyData;
    BloodEffect bloodEffect;

    public GameObject blood; 

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerData = playerObject.GetComponent<PlayerData>();
        enemyData = GetComponent<EnemyData>();
        bloodEffect = GetComponent<BloodEffect>(); 
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        enemyData.hitpoints -= PlayerData.damage; 
    }

    //public void BloodEffect()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        Instantiate(blood, transform); 

    //    }
    //}

    public void DeathEffect()
    {

    }

    // collisions with other objects 
    private void OnTriggerEnter2D(Collider2D other)
    {
        // should switch tag here 
        if (other.transform.tag == "Player")
        {
            //DamagePlayer();
        }
        else if (other.transform.tag == "Pet")
        {
            Debug.Log("Pet collision with enemy.");
            // game over 
            // load title screen or refresh level 
            // lives? 
            PlayerData.lives--; 
            Application.Quit();
        }
        else if (other.transform.tag == "Projectile")
        {            
            TakeDamage(PlayerData.damage);
            Destroy(other.gameObject); 
        }
        else if (other.transform.tag == "SlowProjectile")
        {
            TakeDamage(PlayerData.damage);
            enemyData.movementSpeed -= PlayerData.slowAmount;
            Destroy(other.gameObject);
        }
        else if (other.transform.tag == "SnareProjectile")
        {
            TakeDamage(PlayerData.damage);
            enemyData.movementSpeed = 0f;
            // remember to start timer

            Destroy(other.gameObject); 
            //other.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce());
        }

        if (enemyData.hitpoints <= 0)
        {
            //bloodEffect.CreateBlood(); 
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
