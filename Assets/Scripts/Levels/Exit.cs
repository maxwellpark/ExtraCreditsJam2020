using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    GameObject playerObject;
    GameObject levelManagerObject; 
    LevelManager levelManagerScript;
    public string nextLevel;
    public Vector2 exitPosition;
    public float yExit; 

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        //yExit = 69.60f;

        // make dynamic 
        //exitPosition = new Vector3(499.4f, 312.2f, 0f);

        //levelManagerObject = GameObject.Find("LevelManager");
        //levelManagerScript = levelManagerObject.GetComponent<LevelManager>();

        //SceneManager.LoadScene("Route 1"); 
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerObject.transform.position.y >= yExit)
        //{
        //    ExitLevel();
        //}
        if (playerObject.transform.position.y >= yExit)
        {
            //ExitLevel();
            SceneManager.LoadScene(nextLevel); 
        }
    }

    void ExitLevel()
    {
        Debug.Log("Exit level method fired.");
        SceneManager.LoadScene(nextLevel);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        Debug.Log("Exit collision");
    //        //SceneManager.LoadScene("Route 1"); 
    //        SceneManager.LoadScene(nextLevel); 
    //        //levelManagerScript.TranisitionToNextLevel(); 
    //    }
    //}
}
