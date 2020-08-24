using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 roamingPosition; 
    float lowerBound = 1f;
    float upperBound = 5f; 
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        roamingPosition = GetRoamingPosition(); 
    }

    // Update is called once per frame
    void Update()
    {

        float reachedPositionDistance = 1f; 
        if (Vector3.Distance(transform.position, roamingPosition) < reachedPositionDistance)
        {
            // Get new roaming dest. if dest. reached 
            roamingPosition = GetRoamingPosition();
        }
    }

    private Vector3 RandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + RandomDirection() * Random.Range(lowerBound, upperBound); 
    }
}
