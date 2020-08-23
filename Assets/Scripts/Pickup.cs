using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    health, item 
}

// break these out later 
[CreateAssetMenu(fileName = "Pickup", menuName = "ScriptableObjects/Pickup", order = 1)]
public class Pickup : ScriptableObject
{
    public GameObject prefab;
    public Weapon weapon; 
    public Vector2 coordinates;
    public int health;
    public int damage; 
    public PickupType type;
    public WeaponType weaponType; 

    public void TriggerPickup()
    {
        Debug.Log("Pickup triggered!"); 
        if (type == PickupType.health)
        {
            PlayerData.healthPoints += health; 
        }
        else if (type == PickupType.item)
        {
            // inventory too costly 
            //PlayerData.weapon = weapon;
            //ProjectileManager.currentWeapon = weapon;
            //ProjectileManager.currentWeaponPrefab = weapon.prefab;
            PlayerData.damage = damage; 
            ProjectileManager.weaponType = weaponType;
        }

        
    }
}
