using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    public float movementSpeed = 5f;
    public float nextDestinationDistance = 3f; // How far until it moves again 

    Path path;
    int currentDestination; 
    bool completedPath; 

    Seeker seeker;
    Rigidbody2D rb; 


    void Start()
    {
        seeker = GetComponent<Seeker>(); 
        rb = GetComponent<Rigidbody2D>();

        seeker.StartPath(rb.position, target.transform.position, DestinationReached);
    }

    void Update()
    {
        
    }

    void DestinationReached(Path _path)
    {
        if (!path.error)
        {
            path = _path;

            // Reset path point 
            currentDestination = 0; 
        }
    }
}
