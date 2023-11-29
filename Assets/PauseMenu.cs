using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool IsMainMenu = false;
    public static bool IsLevelSelect = false;

    public GameObject pauseMenuUI;
    public GameObject mainMenuUI;
    // public GameObject levelSelectUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!GameIsPaused && !IsMainMenu && !IsLevelSelect)
            {
                Pause();
            }
            else if (GameIsPaused && !IsMainMenu && !IsLevelSelect)
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        mainMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = false;
        IsMainMenu = true;
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game...");
        int levelToLoad = LevelScript.selectedLevel;
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1f;
        GameIsPaused = false;
        IsMainMenu = false;
    }


    // TODO: Implement other methods like RestartGame and LoadLevelSelect
}
