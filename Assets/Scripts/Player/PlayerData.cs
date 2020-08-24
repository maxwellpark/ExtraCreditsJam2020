using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int damage = 1;
    public static int slowAmount = 0;
    public static int lives = 3;
    // movement data 

    public static bool playerDead; 
    public static bool gameOver;

    private void Start()
    {
        // temporary default workaround: 
        damage = 1;
        slowAmount = 0;
        PlayerMovement.speed = 5f;
    }
}
