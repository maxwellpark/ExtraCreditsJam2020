using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishedGame : MonoBehaviour
{
    public GameObject UI;
    public Button titleBtn; 

    void Start()
    {
        UI.SetActive(false);
        titleBtn.onClick.AddListener(delegate { GoToTitleScreen(); });
    }

    public void ShowEndScreen()
    {
        UI.SetActive(true);
    }

    void GoToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen"); 
    }

}
