using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject gunBarrel;

    public Transform petTransform; 
    
    public GameObject endScreenUI;

    //OnLevelWasLoaded()
    //{

    //}

    //SceneManager.activeSceneChanged

    // custom audio 
    ProjectileManager pm;
    float rof = 30f;
    float timer;

    void Start()
    {
        timer = 500f; 
        //pm = GetComponent<ProjectileManager>();
        //timer = rof; 
    }

    void Update()
    {
        //if (timer <= 0)
        //{
        //    ShootRocket();
        //    //pm.FireProjectile(pm.startingWeaponPrefab);
        //    //timer = rof; 
        //    timer = 500f; 
        //}
        //timer--; 
    }

    void ShootRocket()
    {
        GameObject newRocket = Instantiate(rocketPrefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
        //newRocket.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Pet").transform;
        newRocket.GetComponent<AIDestinationSetter>().target = petTransform;
    }


}
