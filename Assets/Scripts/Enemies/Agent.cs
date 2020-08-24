using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    //public 
    float movementSpeed = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AIPath>().maxSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
