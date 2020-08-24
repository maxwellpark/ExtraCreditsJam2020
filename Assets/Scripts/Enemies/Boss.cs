using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject gunBarrel; 

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
        if (timer <= 0)
        {
            ShootRocket();
            //pm.FireProjectile(pm.startingWeaponPrefab);
            //timer = rof; 
        }
        timer--; 
    }

    void ShootRocket()
    {
        Instantiate(rocketPrefab, gunBarrel.transform);
    }


}
