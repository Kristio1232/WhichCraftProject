using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject MiniGame;
    public GameObject MiniGameWinMenu;
    public GameObject MiniGameLoseMenu;
    public GameObject AreYouSureMenu;

    void Start()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (AreYouSureMenu.activeSelf)
            {
                AreYouSureMenu.SetActive(false);
               // pauseMenuUI.SetActive(true);
            }

            if (MiniGame.activeSelf || MiniGameLoseMenu.activeSelf || MiniGameWinMenu.activeSelf)
            {
                MiniGame.SetActive(false);
                MiniGameWinMenu.SetActive(false);
                MiniGameLoseMenu.SetActive(false);
            }
            else
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
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ClickedYes()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickedNo()
    {
        AreYouSureMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        AreYouSureMenu.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
}
