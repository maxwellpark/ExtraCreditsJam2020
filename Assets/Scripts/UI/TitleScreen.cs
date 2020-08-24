using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public Button enterGameBtn;
    public GameObject gameOverText; 

    // Start is called before the first frame update
    void Start()
    {
        enterGameBtn.onClick.AddListener(delegate { EnterGame(); }); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnterGame()
    {
        PlayerData.gameOver = false; 
        SceneManager.LoadScene("Caves"); 
    }

    void DisplayGameOverText()
    {
        if (PlayerData.gameOver)
        {
            gameOverText.SetActive(true); 
        }
    }
}
