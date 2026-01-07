using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStarter : MonoBehaviour
{
    public Transform spawnParent; // Assign an empty parent object in the Inspector for organization

    void Start()
    {
        // GameManager.Instance is available because it persisted across scenes
        if (GameManager.Instance != null)
        {
            // List<GameObject> prefabs = GameManager.Instance.prefabsToInstantiate;
            float spawnYOffset = 0f;

            // foreach (GameObject prefab in prefabs)
            // {
            //     if (prefab != null)
            //     {
            //         // Instantiate the prefab in the current scene
            //         Vector3 spawnPosition = new Vector3(0, spawnYOffset, 0);
            //         Instantiate(prefab, spawnPosition, Quaternion.identity, spawnParent);
            //         spawnYOffset += 2f; // Add vertical spacing
            //     }
            // }
            
            // Optional: Clear the list once they are instantiated
            // GameManager.Instance.prefabsToInstantiate.Clear();
        }
    }
}
