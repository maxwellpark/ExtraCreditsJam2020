using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishedGame : MonoBehaviour
{
    public GameObject UI;
    public Button titleBtn; 

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        titleBtn.onClick.AddListener(delegate { GoToTitleScreen(); });
    }

    // Update is called once per frame
    void Update()
    {
        
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
