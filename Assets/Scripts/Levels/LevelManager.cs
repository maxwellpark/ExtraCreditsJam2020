using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject player; 
    GameObject pet;

    float petSizeIncrease = 0.25f; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pet = GameObject.FindGameObjectWithTag("Pet"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TranisitionToNextLevel()
    {


        // Scale up pet each level 
        pet.transform.localScale += new Vector3(petSizeIncrease, petSizeIncrease, 0f); 
    }
}
