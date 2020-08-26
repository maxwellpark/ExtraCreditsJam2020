using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public Transform petTransform; 
    public GameObject tileMap; 

    AIPath aiPath;
    AIDestinationSetter destinationSetter;

    public float movementSpeed; 
    public float hitpoints;
    public int damage;
    public bool firstWave = true;

    void Start()
    {
        aiPath = GetComponent<AIPath>();
        aiPath.maxSpeed = movementSpeed;
        aiPath.enableRotation = false;
        destinationSetter = GetComponent<AIDestinationSetter>();

        //taggedPet = GameObject.FindGameObjectWithTag("Pet").transform;
        //Debug.Log(taggedPet); 
        //destinationSetter.target = taggedPet;

        //destinationSetter.target = GameObject.FindGameObjectWithTag("Pet").transform;
        destinationSetter.target = petTransform;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; 

        // hp should be dependent on enemy type...
        if (hitpoints == 0)
        {
            hitpoints = 5; 
        }
    }

    void Update()
    {
        //Debug.Log("Target pos: " + destinationSetter.target.transform.position); 
    }
}
