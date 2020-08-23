using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// remember to trigger animation on collision 
public class PickupObject : MonoBehaviour
{
    public Pickup pickup;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pickup.TriggerPickup();
            Destroy(gameObject);

        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        pickup.TriggerPickup();
    //        Destroy(gameObject); 

    //    }
    //}
}
