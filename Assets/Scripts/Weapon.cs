using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    public GameObject prefab;
    public float attackSpeed;
    public float attackCooldown; 
    public float duration;

    // use multiple gun barrels? 
    // or reposition/rotate them post-instantiation 
    public int projectileCount;  

    // width or just use prefab bounding box? 


}
