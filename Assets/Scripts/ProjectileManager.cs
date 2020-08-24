using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject projectileContainer;
    public GameObject gunBarrel;

    public Vector3 projectileDropOff = new Vector3(64f, 64f, 0f); 
    public float muzzleVelocity = 10f; 
    

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            FireProjectile(); 
        }

        //DestroyOldProjectiles();
    }

    void FireProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
        //newProjectile.transform.parent = projectileContainer.transform; 
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.AddForce(gunBarrel.transform.up * muzzleVelocity, ForceMode2D.Impulse);    
    }

    void DestroyOldProjectiles()
    {
        foreach (Transform _transform in projectileContainer.transform)
        {
            // Set a boundary 
            if (_transform.position.x >= gameObject.transform.position.x + projectileDropOff.x ||
                transform.position.x <= gameObject.transform.position.x - projectileDropOff.x ||
                transform.position.y >= gameObject.transform.position.y + projectileDropOff.y ||
                transform.position.y <= gameObject.transform.position.y - projectileDropOff.y)
            {
                Destroy(_transform.gameObject);
            }
        }
    }
}
