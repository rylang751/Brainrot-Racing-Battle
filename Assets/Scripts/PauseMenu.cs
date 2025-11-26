using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool gameIsPaused = false; 
    

    // Start is called before the first frame update
    void Start()
    {
        if(pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
         Time.timeScale = 1f;
         gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
             ResumeGame();
            }
            else
            {
            PauseGame();
            }
        
        }
    }

    public void PauseGame()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true); // show the pause menu
        }
       Time.timeScale = 0f; // stop game time
        gameIsPaused = true;
        Cursor.visible = true; //show cursor for menu interaction
       Cursor.lockState = CursorLockMode.None; // Unlock cursor
    }

    public void ResumeGame()
    {
        if (pauseMenu != null);
        {
            pauseMenu.SetActive(false);
        }
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitRace()
    {
        SceneManager.LoadScene("Character Select");
    }

    
}
