using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject levelSelectUI;
    public GameObject pauseMenuUI;
    
    public GameObject mainMenuUI;

    // Quick play button
    public void PlayGame()
    {
        Debug.Log("Starting game...");
        int levelToLoad = LevelScript.selectedLevel; // Use the stored level number
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1f;
        PauseMenu.IsMainMenu = false;

    }

    public void LoadLevelSelect()
    {
        Debug.Log("Loading level select...");
        levelSelectUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        mainMenuUI.SetActive(false);
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = false;
        PauseMenu.IsLevelSelect = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
