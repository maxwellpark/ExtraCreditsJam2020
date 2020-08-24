using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // custom audio 
    ProjectileManager pm;
    float rof = 30f;
    float timer;

    void Start()
    {
        pm = GetComponent<ProjectileManager>();
        timer = rof; 
    }

    void Update()
    {
        if (timer <= 30)
        {
            pm.FireProjectile(pm.startingWeaponPrefab);
            timer = rof; 
        }
        timer--; 
    }


}
