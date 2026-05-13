using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSelect : MonoBehaviour
{
    public Button SharkButton;
    public Button BallerinaButton;
    public Button TreeButton;
    public Button MonkeyButton;
    
    // Add a reference for your Quit Button if you want to control it via code
    public Button QuitButton; 

    public static CharacterSelect Instance { get; private set; }
    public GameObject selectedCharacterPrefab; 
    
    public GameObject SharkPrefab;
    public GameObject BallerinaPrefab;
    public GameObject TreePrefab;
    public GameObject MonkeyPrefab;

    public UnityEvent m_MyEvent = new UnityEvent();
    public static string[] characterNames;
    public static string selectedCharacter;

    void Start()
    {
        characterNames = new string[] {"characters"};
    }

    public void Startrace()
    {
        selectedCharacter = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("Gameplay");
    }

    // New method to go back to the previous scene
    public void QuitToMenu()
    {
        // Replace "MainMenu" with the exact name of your previous scene
        SceneManager.LoadScene("Menu"); 
    }
}