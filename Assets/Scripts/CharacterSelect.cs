using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

   public static string selectedCharacter;

    // Start is called before the first frame update
    void Start()
    {
      characterNames = new string[] {"characters"};
      Debug.Log("Character selected");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Startrace()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        selectedCharacter = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("Test Level");
    }




}
