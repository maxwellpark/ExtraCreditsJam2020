using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    GameObject playerObject; 
    public GameObject agentPrefab;
    public GameObject hazmatPrefab;
    public GameObject parentObject;

    public int enemyCount = 5; 
    public int killCount;
    public int deathCount;

    // tune these values 
    float yThreshold = 256f; 
    float valueRange = 16f; 

    public Text killCountText;
    public Text deathCountText; 

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); 
    }

    void Update()
    {
        if (playerObject.transform.position.y >= yThreshold)
        {
            SpawnBehindEnemy((int)Random.Range(10f, 30f));
        }
    }

    void SpawnBehindEnemy(int n)
    {
        for (int i = 0; i < n; i++)
        {
            GameObject prefab = Random.Range(0f, 1f) == 0f ? agentPrefab : hazmatPrefab;
            GameObject newEnemy = Instantiate(prefab);
            newEnemy.transform.position += new Vector3(GetRandomCoordinate(), GetRandomCoordinate(), 0f);
        }
    }

    float GetRandomCoordinate()
    {
        return Random.Range(-valueRange, valueRange);
    }

    void SpawnEnemy()
    {
        //enemyCount = transform.childCount * 
        GameObject newEnemy = new GameObject("Enemy");
        newEnemy.transform.parent = parentObject.transform;

    }
}
