using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    standard, dual, tri, slow, medium, blast
}

// weapon scriptable objects not currently working
// as expected
public class ProjectileManager : MonoBehaviour
{
    public GameObject startingWeaponPrefab;
    public GameObject dualShotPrefab;
    public GameObject triShotPrefab;
    public GameObject slowProjectilePrefab;
    public GameObject snakeShotPrefab;
    public GameObject theMediumOnePrefab; 
    public GameObject theBigOnePrefab;

    GameObject playerObject;
    public static GameObject gunBarrel; 
    public static GameObject currentWeaponPrefab;
    public static WeaponType weaponType = WeaponType.standard;

    public static float weaponDuration;
    public static bool weaponActive;

    public float muzzleVelocity = 10f;
    public float spreadDistance = 2f; 
    

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        gunBarrel = GameObject.Find("GunBarrel"); 
        currentWeaponPrefab = startingWeaponPrefab;
        weaponType = WeaponType.standard;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            FireProjectile(SetProjectilePrefab());

        }
        
        if (weaponActive)
        {
            if (weaponDuration <= 0)
            {
                weaponActive = false;
                currentWeaponPrefab = startingWeaponPrefab;
                weaponDuration = 0f; 
            }
            weaponDuration--; 
        }

    }

    public void FireProjectile(GameObject prefab)
    {
        GameObject newProjectile = Instantiate(prefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        // Make bullets pass through player 
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), playerObject.GetComponent<Collider2D>());

        rb.AddForce(gunBarrel.transform.up * muzzleVelocity, ForceMode2D.Impulse);

        if (prefab == dualShotPrefab)
        {
            GameObject secondProjectile = Instantiate(
                prefab, gunBarrel.transform.position + new Vector3(spreadDistance, 0f, 0f), gunBarrel.transform.rotation);
            Physics2D.IgnoreCollision(secondProjectile.GetComponent<Collider2D>(), playerObject.GetComponent<Collider2D>());
            rb = secondProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(gunBarrel.transform.up * muzzleVelocity, ForceMode2D.Impulse);
        }
        // stack modifiers?
        // break out wep mods into separate class*
        //if (prefab == snakeShotPrefab)
        //{

        //}
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
            case WeaponType.slow:
                return slowProjectilePrefab;
            case WeaponType.medium:
                return theMediumOnePrefab; 
            case WeaponType.blast:
                return theBigOnePrefab;
            default:
                return startingWeaponPrefab;
        }
    }
}
