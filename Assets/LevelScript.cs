using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    // Assuming you have references to the main menu UI and current level UI
    public GameObject mainMenuUI;
    public GameObject currentLevelUI;  // Adjust this based on your actual UI structure

    public static int selectedLevel = 1;  // Default to 1 or a valid level index
    public static bool levelPassed = false;  // TODO: Implement lavel passed method to unblock next higher level

    public void LoadLevel(int levelNum)
    {
        if (levelNum == 1)
        {
            selectedLevel = levelNum;
            Debug.Log("Loading level: " + levelNum);
            SceneManager.LoadScene(levelNum);
            Time.timeScale = 1f;
            PauseMenu.GameIsPaused = false;
            PauseMenu.IsMainMenu = false;
            PauseMenu.IsLevelSelect = false;
        }
    }

    public void BackToMainMenu()
    {
        Debug.Log("Returning to main menu...");
        mainMenuUI.SetActive(true);
        
        // Deactivate the current level UI if needed
        if (currentLevelUI != null)
        {
            currentLevelUI.SetActive(false);
        }

        // Update the game state
        PauseMenu.GameIsPaused = false;
        PauseMenu.IsMainMenu = true;
        PauseMenu.IsLevelSelect = false;
        Time.timeScale = 0f;  // Assuming you want the time to run normally in the main menu
    }

}
