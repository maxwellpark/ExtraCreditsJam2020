using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameObject player; 
    GameObject pet;
    GameObject waveOneContainer;
    GameObject waveTwoContainer; 

    public Scene[] levels; 

    public static int currentLevel = 0; 
    float petSizeIncrease = 0.25f; 

     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pet = GameObject.FindGameObjectWithTag("Pet");
        waveOneContainer = GameObject.Find("WaveOneContainer");
        waveTwoContainer = GameObject.Find("WaveTwoContainer"); 
    }

    void Update()
    {
        //if (waveOneContainer.transform.childCount <= 0)
        //{
        //    NewWave(); 
        //}
    }

    void NewWave()
    {
        foreach (Transform enemy in waveTwoContainer.transform)
        {
            enemy.gameObject.SetActive(true); 
        }
    }

    void TagIn()
    {

    }

    bool FirstWaveDead()
    {
        foreach (Transform transform in transform.root)
        {
            if (transform.tag == "Enemy")
            {
                return false;
            }
        }
            return true; 
    }

    // call this from exit script oncollider method 
    void TranisitionToNextLevel()
    {
        currentLevel++;

        // Scale up pet each level 
        pet.transform.localScale += new Vector3(petSizeIncrease, petSizeIncrease, 0f);

        // Load next level  
        SceneManager.LoadScene(levels[currentLevel].name); 
    }
}
