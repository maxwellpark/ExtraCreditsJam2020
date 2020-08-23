using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject playerObject;
    public PlayerData playerData;

    private float healthPoints = 5; 
    private float movementRange;
    private float damageRange;




    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerData = playerObject.GetComponent<PlayerData>(); 
    }

    void Update()
    {
        
    }

    public Vector3 GenerateRandomNavMeshPosition()
    {
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * movementRange;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPosition, out navHit, 1.0f, NavMesh.AllAreas);
        return navHit.position;
    }

    private void DamagePlayer()
    {
        PlayerData.healthPoints -= EnemyConstants.damage; 
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= PlayerData.damage; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGG");
        if (other.transform.tag == "Player")
        {
            DamagePlayer();
        }
        else if (other.transform.tag == "Projectile")
        {
            //getcomponent<projectile>.damage 
            
            TakeDamage(CombatConstants.basicProjectileDamage);
            Destroy(other.gameObject); 

            if (healthPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
