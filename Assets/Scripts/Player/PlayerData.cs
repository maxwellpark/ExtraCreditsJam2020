using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int damage = 2; 
    public static int healthPoints = 10;
    public static int abilityCooldown = 60;

    // defaults 
    // make more constants 

    public static Weapon weapon;

    private void Start()
    {
        damage = 1;
        healthPoints = 10;
        abilityCooldown = 60; 
    }


    private void OnGUI()
    {
        

    }
    // movement data 
}
