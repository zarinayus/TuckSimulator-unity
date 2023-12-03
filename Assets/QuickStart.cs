using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickStart : MonoBehaviour
{
    public static int startScene = 1;

    public void StartGame()
    {
        Debug.Log("Starting game...");
        SceneManager.LoadScene(startScene);
        Time.timeScale = 1f;
    }
}
