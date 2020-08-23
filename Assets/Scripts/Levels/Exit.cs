using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    GameObject levelManagerObject; 
    LevelManager levelManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        levelManagerObject = GameObject.Find("LevelManager");
        levelManagerScript = levelManagerObject.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Exit collision");
            SceneManager.LoadScene("TestLevel2"); 
            //levelManagerScript.TranisitionToNextLevel(); 
        }
    }
}
