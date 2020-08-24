using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject bloodPrefab;
    GameObject leakedBlood;
    float bloodVelocity;
    float timer = 60f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            Destroy(leakedBlood);
        }
        timer--;
    }

    public void CreateBlood()
    {
        leakedBlood = Instantiate(bloodPrefab);
        Rigidbody2D rb = bloodPrefab.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bloodVelocity, ForceMode2D.Impulse); 
    }
}
