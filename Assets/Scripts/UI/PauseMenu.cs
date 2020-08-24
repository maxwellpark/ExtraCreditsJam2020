using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuUI;
    public Image panelImg; 
    public Button resumeBtn;
    public bool gamePaused;
    //public playerDead;

    public static string resumeText = "Resume Game";
    public static string retryText = "Retry Level"; 

    void Start()
    {
        gamePaused = false; 
        menuUI.SetActive(false);
        resumeBtn.onClick.AddListener(delegate { TogglePauseMenu(); });
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause Btn Fired");
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        gamePaused = !gamePaused;

        // bring up menu and freeze time 
        menuUI.SetActive(gamePaused);
        Time.timeScale = gamePaused ? 0f : 1f;

        // alpha update 
        var tempColour = panelImg.color;
        tempColour.a = gamePaused ? 1f : 0f;
        panelImg.color = tempColour;

        //resumeBtn.GetComponentInChildren<Text>().text = playerDead ? retryText : resumeText;

        //if (playerDead)
        //{
        //    resumeBtn.GetComponentInChildren<Text>().text = retryText;
        //    resumeBtn.onClick.RemoveAllListeners();
        //    resumeBtn.onClick.AddListener(delegate { RetryLevel(); });
        //}
    }

    //public static void RetryLevel()
    //{
    //    playerDead = false;
    //    Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    //    //resumeBtn.GetComponentInChildren<Text>().text = resumeText;
    //    //resumeBtn.onClick.RemoveAllListeners();
    //    //resumeBtn.onClick.AddListener(delegate { TogglePauseMenu(); });
    //}
}
