using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject playerPrefab;

    public List<GameObject> prefabsToInstantiate; 

    // Start is called before the first frame update
    void Awake()
    {
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

     public void LoadSceneAndSpawnPrefabs(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
