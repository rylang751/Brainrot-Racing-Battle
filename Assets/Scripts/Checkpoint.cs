using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Assign a unique number to each checkpoint in the Inspector (1, 2, 3...)
    public int checkpointIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Tell the LapManager this checkpoint was hit
            FindObjectOfType<LapManager>().PlayerHitCheckpoint(checkpointIndex);
        }
    }
}
