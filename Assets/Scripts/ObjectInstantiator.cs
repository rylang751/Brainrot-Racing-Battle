using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiator : MonoBehaviour
{
    public Transform spawnParent; 
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            List<GameObject> prefabsToSpawn = GameManager.Instance.prefabsToInstantiate;
            Vector3 currentSpawnPosition = Vector3.zero; 

            foreach (GameObject prefabAsset in prefabsToSpawn)
            {
                if (prefabAsset !=null)
                {
                  
                  GameObject spawnedInstance = Instantiate(prefabAsset, currentSpawnPosition, Quaternion.identity, spawnParent);

                  if (prefabAsset == GameManager.Instance.playerPrefab)
                  {
                    spawnedInstance.AddComponent<PlayerController>();
                    spawnedInstance.tag = "Player";
                  }
                  else
                  {
                    spawnedInstance.AddComponent<AIController>();
                  }

                  currentSpawnPosition.x +=3f;

                   
                }
            } 
        }
    }

  
}
