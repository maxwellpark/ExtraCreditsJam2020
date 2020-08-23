using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    GameObject player; 
    GameObject pet;
    GameObject waveOneContainer;
    GameObject waveTwoContainer;

    [SerializeField]
    public Level[] levels; 

    public static int currentLevel = 0; 
    float petSizeIncrease = 0.25f;

    public Tilemap tilemap;

    GameObject exit;
    //Tile exitTile;
    //TileBase exitTileBase; 
    //Vector3Int exitPosition = new Vector3Int(1340, 434, 0); 

     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pet = GameObject.FindGameObjectWithTag("Pet");
        waveOneContainer = GameObject.Find("WaveOneContainer");
        waveTwoContainer = GameObject.Find("WaveTwoContainer");

        //exitTileBase = tilemap.GetTile(exitPosition); 
        Debug.Log(levels[currentLevel].scenePath);
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
        //if (FirstWaveDead())
        //{

        //}
    }

    [System.Obsolete]
    bool FirstWaveDead()
    {
        object[] obj = FindSceneObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            if (g.tag == "Enemy")
            {
                return false; 
            }
        }
        return true; 
    }

    // call this from exit script oncollider method 
    public void TranisitionToNextLevel()
    {
        currentLevel++;

        // Scale up pet each level 
        pet.transform.localScale += new Vector3(petSizeIncrease, petSizeIncrease, 0f);

        // Load next level  
        SceneManager.LoadScene(levels[currentLevel].scenePath); 
    }
}
