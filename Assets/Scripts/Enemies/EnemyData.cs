using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public float movementSpeed; 
    public float hitpoints;
    public int damage;
    public bool firstWave = true;
    AIPath aiPath;
    AIDestinationSetter destinationSetter; 

    // separate prefab for wave 1, 2, 3, ... 

    void Start()
    {
        aiPath = GetComponent<AIPath>();
        aiPath.maxSpeed = movementSpeed;
        aiPath.enableRotation = false;
        destinationSetter = GetComponent<AIDestinationSetter>();
        destinationSetter.target = GameObject.FindGameObjectWithTag("Pet").transform; 
    }

    void Update()
    {
        
    }
}
