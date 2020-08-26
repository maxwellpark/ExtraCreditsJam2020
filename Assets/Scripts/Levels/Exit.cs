using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    GameObject playerObject;
    public string nextLevel;
    public Vector2 exitPosition;
    public float yExit; 

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // change this later to handle exits that are not 
    // on the north wall...
    void Update()
    {
        if (playerObject.transform.position.y >= yExit)
        {
            SceneManager.LoadScene(nextLevel); 
        }
    }
}
