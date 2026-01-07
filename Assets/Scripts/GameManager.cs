using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject playerPrefab;

    /* We will use a Dictory to associate a button with a prefab */
    private Dictionary<Button, GameObject> buttonObjectMap = new Dictionary<Button, GameObject>();
    // References to your scene lists
    public List<Button> uiButtons;
    public List<GameObject> characterPrefabs;
   

    //public List<GameObject> prefabsToInstantiate; 


    // Start is called before the first frame update
    void Awake()
    {
        // Ensure both lists have the same count before mapping
        if (uiButtons.Count != characterPrefabs.Count)
        {
            Debug.LogError("Button and GameObject lists do not have the same number of elements! Cannot map.");
            return;
        }

        // Map the items based on their index in the list
        for (int i = 0; i < uiButtons.Count; i++)
        {
            Button currentButton = uiButtons[i];
            GameObject currentObject = characterPrefabs[i];

            // Add the pairing to the dictionary
            buttonObjectMap.Add(currentButton, currentObject);

            // Add a listener to the button's onClick event
            // This links the button press to our handling function
            currentButton.onClick.AddListener(() => OnButtonClicked(currentButton));
        }


        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            
        }
        else
        {
            // If another GameManager instance already exists, destroy this duplicate
            Destroy(gameObject);
        }
    }

    // This function is called every time a mapped button is clicked
    private void OnButtonClicked(Button clickedButton)
    {
        // Use the dictionary to find the corresponding GameObject
        if (buttonObjectMap.TryGetValue(clickedButton, out GameObject targetObject))
        {
            Debug.Log($"Button clicked! Adding component to: {targetObject.name}");
            
            // Call the function to add the component to the retrieved object
            AddComponentToObject(targetObject);
        }
        else
        {
            Debug.LogWarning("Clicked button was not found in the map!");
        }
    }

     // Function to add a specific component type
    private void AddComponentToObject(GameObject obj)
    {
        // Example: Add a Rigidbody component if it doesn't already have one
        if (obj.GetComponent<PlayerController>() == null)
        {
            obj.AddComponent<PlayerController>();
            Debug.Log("PC added to " + obj.name);
        }
        else
        {
            Debug.Log(obj.name + " already has a PC.");
        }
    }

    public void LoadSceneAndSpawnPrefabs(string sceneName)
    {
        // selectedCharacter = EventSystem.current.currentSelectedGameObject.name;
        // Debug.Log(selectedCharacter);
        SceneManager.LoadScene(sceneName);

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
