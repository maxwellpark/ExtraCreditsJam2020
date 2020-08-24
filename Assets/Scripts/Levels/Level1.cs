using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Levels as scriptableObjects, 
// LevelManager static method governs them 

public class Level1 : MonoBehaviour
{
    public GameObject enemyPrefab; 
    int enemyCount = 5;

    public LayerMask enemyLayer; 

    Vector2[] enemyPositions = new Vector2[]
    {
        new Vector2(-1f, 1f),
        new Vector2(0f, 1f),
        new Vector2(1f, 1f),
        new Vector2(-1f, 2f),
        new Vector2(-1f, 1.5f)
    };

    // random coords in range defined. 
    // but account for overlapping pos. 

   
}
