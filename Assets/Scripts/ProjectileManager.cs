using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    standard, dual, tri, blast
}

// weapon scriptable objects not currently working
// as expected
public class ProjectileManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject projectileContainer;
    public GameObject gunBarrel;

    public GameObject startingWeaponPrefab;
    public GameObject dualShotPrefab;
    public GameObject triShotPrefab;
    public GameObject slowProjectilePrefab; 
    public GameObject theBigOnePrefab; 

    GameObject playerObject;

    public Weapon startingWeapon;
    public static Weapon currentWeapon;
    public static GameObject currentWeaponPrefab;

    public static WeaponType weaponType = WeaponType.standard;

    public Vector3 projectileDropOff = new Vector3(64f, 64f, 0f); 
    public float muzzleVelocity = 10f;

    float spreadDistance = 0.2f; 
    

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        currentWeapon = startingWeapon;
        PlayerData.weapon = startingWeapon;
        currentWeaponPrefab = startingWeaponPrefab;
        weaponType = WeaponType.standard;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            FireProjectile(SetProjectilePrefab()); 
        }

        //DestroyOldProjectiles();
    }

    void FireProjectile(GameObject prefab)
    {
        GameObject newProjectile = Instantiate(prefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
        Debug.Log(currentWeaponPrefab);
        Debug.Log(gunBarrel.transform); 
        //newProjectile.transform.parent = projectileContainer.transform; 

        // Make bullets pass through player 
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), playerObject.GetComponent<Collider2D>()); 

        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.AddForce(gunBarrel.transform.up * currentWeapon.attackSpeed, ForceMode2D.Impulse);   
        
        if (prefab == dualShotPrefab)
        {
            GameObject secondProjectile = Instantiate(
                prefab, gunBarrel.transform.position + new Vector3(spreadDistance, 0f, 0f), gunBarrel.transform.rotation);
            Physics2D.IgnoreCollision(secondProjectile.GetComponent<Collider2D>(), playerObject.GetComponent<Collider2D>());
            rb = secondProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(gunBarrel.transform.up * currentWeapon.attackSpeed, ForceMode2D.Impulse);
        }
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

    private GameObject SetProjectilePrefab()
    {
        switch (weaponType)
        {
            case WeaponType.standard:
                return startingWeaponPrefab;
            case WeaponType.dual:
                return dualShotPrefab;
            case WeaponType.tri:
                return triShotPrefab;
            case WeaponType.blast:
                return theBigOnePrefab;
            default:
                return startingWeaponPrefab; 
        }
    }
}
