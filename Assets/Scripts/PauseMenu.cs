using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool gameIsPaused = false; 

    void Start()
    {
        if(pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused) { ResumeGame(); }
            else { PauseGame(); }
        }
    }

    public void PauseGame()
    {
        if (pauseMenu != null) { pauseMenu.SetActive(true); }
        Time.timeScale = 0f; 
        gameIsPaused = true;
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
    }

    public void ResumeGame()
    {
        if (pauseMenu != null) { pauseMenu.SetActive(false); } // Semicolon bug removed
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitRace()
    {
        Time.timeScale = 1f; // Force unpause before shifting scenes
        gameIsPaused = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Character Select");
    }
}