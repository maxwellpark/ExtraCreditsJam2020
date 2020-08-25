using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    health, speed, item 
}

// break these out later 
[CreateAssetMenu(fileName = "Pickup", menuName = "ScriptableObjects/Pickup", order = 1)]
public class Pickup : ScriptableObject
{
    public GameObject prefab;
    public Vector2 coordinates;
    public float duration; 
    public int health;
    public int damage;
    public int speedIncrease;
    public PickupType type;
    public WeaponType weaponType; 

    public void TriggerPickup()
    {
        //Debug.Log("Pickup triggered!"); 

        if (type == PickupType.health)
        {
            //PlayerData.healthPoints += health; 
        }
        else if (type == PickupType.item)
        {
            PlayerData.damage = damage; 
            ProjectileManager.weaponType = weaponType;
            ProjectileManager.weaponActive = true;
            ProjectileManager.weaponDuration = duration;
        }
        else if (type == PickupType.speed)
        {
            PlayerMovement.speed += speedIncrease;

            // speed cap 
            if (PlayerMovement.speed >= 10)
            {
                //PlayerMovement.speed = 10; 
            }
        }

        
    }
}
