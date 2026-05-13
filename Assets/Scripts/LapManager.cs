using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
    public int currentLap = 1;
    public int totalLaps = 3;
    public TextMeshProUGUI lapText;
    public GameObject winScreen;

    [Header("Checkpoint Settings")]
    public int totalCheckpoints; // Set this to the number of checkpoints on your track
    private int nextCheckpointRequired = 1; // Tracks the next checkpoint index needed

    void Start()
    {
        Time.timeScale = 1; // Ensure game is unpaused on start
        if (winScreen != null) winScreen.SetActive(false);
        UpdateLapUI();
    }

    // Called by the Checkpoint script
    public void PlayerHitCheckpoint(int index)
    {
        // Only count it if it's the specific next one in order
        if (index == nextCheckpointRequired)
        {
            nextCheckpointRequired++;
            Debug.Log("Checkpoint " + index + " cleared!");
        }
    }
    
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        // Require ALL checkpoints to be cleared (e.g., if total is 3, next required must be 4)
        if (nextCheckpointRequired > totalCheckpoints)
        {
            if (currentLap >= totalLaps)
            {
                EndGame();
            }
            else
            {
                currentLap++;
                nextCheckpointRequired = 1; // Reset for next lap
                UpdateLapUI();
                Debug.Log("Lap advanced to: " + currentLap);
            }
        }
        else
        {
            Debug.Log(" Lap not counted! Missing checkpoints. Next needed: " + nextCheckpointRequired);
        }
    }
}

    void UpdateLapUI()
    {
        lapText.text = "Lap: " + currentLap + " / " + totalLaps;
    }

    void EndGame()
    {
        Debug.Log("Race Finished!");
        if (winScreen != null) winScreen.SetActive(true);
        Time.timeScale = 0; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}