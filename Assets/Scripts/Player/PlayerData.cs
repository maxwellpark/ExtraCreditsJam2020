using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // break these out into combatconstants 
    public static int damage = 2; 
    public static int healthPoints = 10;
    public static int abilityCooldown = 60;

    public static float slowAmount = 0.5f; 

    // defaults 
    // make more constants 

    public static Weapon weapon;

    private void Start()
    {
        // temporary default workaround: 
        damage = 1;
        healthPoints = 10;
        abilityCooldown = 60;
        PlayerMovement.speed = 3f; 
    }


    private void OnGUI()
    {
        

    }
    // movement data 
}
