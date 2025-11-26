using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    // button gameobjects
   public Button SharkButton;
   public Button BallerinaButton;
   public Button TreeButton;
   public Button MonkeyButton;

   public static CharacterSelect Instance { get; private set; }
   public GameObject selectedCharacterPrefab; 
    // character prefabs to be spawned in
   public GameObject SharkPrefab;
   public GameObject BallerinaPrefab;
   public GameObject TreePrefab;
   public GameObject MonkeyPrefab;

   public UnityEvent m_MyEvent = new UnityEvent();

   public static string[] characterNames;

    // Start is called before the first frame update
    void Start()
    {
        // all characters able to be selected
        SharkButton.onClick.AddListener(() => OnButtonClick("SharkButton"));
        BallerinaButton.onClick.AddListener(() => OnButtonClick("BallerinaButton"));
        TreeButton.onClick.AddListener(() => OnButtonClick("TreeButton"));
        MonkeyButton.onClick.AddListener(() => OnButtonClick("MonkeyButton"));

      characterNames = new string[] {"characters"};
      Debug.Log("Character selected");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Startrace()
    {
        SceneManager.LoadScene("Test Level");
    }

    public void OnButtonClick(string buttonName)
    {
        // allows all characters to be clicken in one method
        if (buttonName == "SharkButton")
        {
            Debug.Log("SharkButton was clicked");
        }
        else if(buttonName == "BallerinaButton")
        {
            Debug.Log("BallerinaButton was clicked");
        }
        else if(buttonName == "TreeButton")
        {
            Debug.Log("TreeButton was clicked");
        }
        else if(buttonName == "MonkeyButton")
        {
            Debug.Log("MonkeyButton was clicked");
        }
    }



}
