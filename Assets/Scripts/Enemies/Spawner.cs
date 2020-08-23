using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemyObject;
    public GameObject parentObject;

    public int enemyCount = 5; 
    public int killCount;
    public int deathCount;

    public Text killCountText;
    public Text deathCountText; 

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        //enemyCount = transform.childCount * 
        GameObject newEnemy = new GameObject("Enemy");
        newEnemy.transform.parent = parentObject.transform;

    }

    void BatchSpawn()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(); 
        }
    }
}
