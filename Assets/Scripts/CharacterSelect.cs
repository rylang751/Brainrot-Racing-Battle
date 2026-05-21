using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Button SharkButton;
    public Button BallerinaButton;
    public Button TreeButton;
    public Button MonkeyButton;
    public Button QuitButton; 

    public static CharacterSelect Instance { get; private set; }
    public static GameObject SelectedCharacterPrefab; 
    
    public GameObject SharkPrefab;
    public GameObject BallerinaPrefab;
    public GameObject TreePrefab;
    public GameObject MonkeyPrefab;

    public static string SelectedCharacterName;

    void Awake()
    {
        // Fail-safe: Force time back to normal instantly when scene initializes
        Time.timeScale = 1f;
        PauseMenu.gameIsPaused = false;
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (Instance == null) { Instance = this; }
    }

    void Start()
    {
        // Re-bind listeners safely via code execution
        if (SharkButton != null)     SharkButton.onClick.AddListener(() => SetCharacter(SharkPrefab, "Shark"));
        if (BallerinaButton != null) BallerinaButton.onClick.AddListener(() => SetCharacter(BallerinaPrefab, "Ballerina"));
        if (TreeButton != null)      TreeButton.onClick.AddListener(() => SetCharacter(TreePrefab, "Tree"));
        if (MonkeyButton != null)    MonkeyButton.onClick.AddListener(() => SetCharacter(MonkeyPrefab, "Monkey"));
        if (QuitButton != null)      QuitButton.onClick.AddListener(QuitToMenu);
    }

    private void SetCharacter(GameObject prefab, string name)
    {
        SelectedCharacterPrefab = prefab;
        SelectedCharacterName = name;
        StartRace();
    }
    public void StartRace()
    {
        try
        {
            // Changed from "Gameplay" to your exact scene name
            SceneManager.LoadScene("Jah-Ziere Gameplay");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Scene loading failed! Error: " + e.Message);
        }
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // Ensure your main menu scene is exactly named "Menu"
    }
}