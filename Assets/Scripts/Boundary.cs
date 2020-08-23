using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{


    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit"); 
        if (collision.transform.tag == "Projectile")
        {
            Destroy(collision.gameObject); 
        }
    }
}
