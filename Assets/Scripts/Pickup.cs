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
    public PickupType type;

    public void TriggerPickup()
    {
        if (type == PickupType.health)
        {
            PlayerData.healthPoints += health; 
        }
        else if (type == PickupType.item)
        {

        }
    }
}
