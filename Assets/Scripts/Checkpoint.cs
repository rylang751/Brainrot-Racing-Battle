using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Changed to FindObjectOfType for compatibility with older Unity versions
            LapManager manager = FindObjectOfType<LapManager>();

            if (manager != null)
            {
                manager.PlayerHitCheckpoint(checkpointIndex);
            }
            else
            {
                Debug.LogError("Checkpoint hit, but LapManager script was not found in the scene!");
            }
        }
    }
}