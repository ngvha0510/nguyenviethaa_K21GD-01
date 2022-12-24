using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    SaveLoad playerdata;
    public static bool GameIsPaused = false;
   
    public GameObject PauseMenuUI;

    private void Start()
    {
        playerdata = FindObjectOfType<SaveLoad>();
    }
    
    public void Menu()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void QuitGame()
    {
        playerdata.PlayerPosSave();
        SceneManager.LoadScene("Menu");
    }
}
