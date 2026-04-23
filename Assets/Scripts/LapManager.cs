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
            // Check if player has visited ALL checkpoints before crossing finish line
            if (nextCheckpointRequired > totalCheckpoints)
            {
                if (currentLap >= totalLaps)
                {
                    EndGame();
                }
                else
                {
                    currentLap++;
                    // Reset checkpoint requirement for the new lap
                    nextCheckpointRequired = 1; 
                    UpdateLapUI();
                }
            }
            else
            {
                Debug.Log("Lap not counted: You missed checkpoints!");
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