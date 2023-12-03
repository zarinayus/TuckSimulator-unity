using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour
{
    public GameObject helpMenu;
    public static bool IsHelpRequested = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!IsHelpRequested)
            {
                OpenHelpMenu();
            }
            else if (IsHelpRequested)
            {
                CloseHelpMenu();
            }
        }
    }

    public void OpenHelpMenu()
    {
        helpMenu.SetActive(true);
        Time.timeScale = 0f;
        IsHelpRequested = true;
    }

    public void CloseHelpMenu()
    {
        helpMenu.SetActive(false);
        if (PauseMenu.GameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        IsHelpRequested = false;
    }
}
