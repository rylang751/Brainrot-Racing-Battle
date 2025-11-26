using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for Button

public class SceneLoaderAndSpawner : MonoBehaviour
{
    public GameObject prefabA;
    public GameObject prefabB;

    public void OnButtonClick()
    {
        if (GameManager.Instance != null)
        {
            // Clear previous list if needed
            GameManager.Instance.prefabsToInstantiate.Clear(); 
            
            // Add the prefabs we want to carry over
            GameManager.Instance.prefabsToInstantiate.Add(prefabA);
            GameManager.Instance.prefabsToInstantiate.Add(prefabB);

            // Load the target scene (make sure scene name matches)
            GameManager.Instance.LoadSceneAndSpawnPrefabs("Test Level");
        }
    }
}
