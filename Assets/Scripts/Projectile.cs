using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject collisionEffect;
    private int effectDelay = 1;
    public int damage; 

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Oncolliisonenter");
    //    GameObject effect = Instantiate(collisionEffect, transform.position, Quaternion.identity);
    //    Destroy(effect, effectDelay);
    //    Destroy(gameObject);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Ontriggerenter");
    //    GameObject effect = Instantiate(collisionEffect, transform.position, Quaternion.identity);
    //    Destroy(effect, effectDelay);
    //    Destroy(gameObject);
    //}
}
