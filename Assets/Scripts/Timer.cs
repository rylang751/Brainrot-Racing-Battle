using UnityEngine;
using TMPro; // Standard for UI text in Unity

public class Timer : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI timerText; // Drag your TextMeshPro object here

    private float _timeElapsed;
    private bool _isRunning = true;

    void Update()
    {
        if (_isRunning)
        {
            // Time.deltaTime is the time since the last frame
            _timeElapsed += Time.deltaTime;
            UpdateDisplay(_timeElapsed);
        }
    }

    void UpdateDisplay(float time)
    {
        // Calculate minutes and seconds
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = (time % 1) * 100;

        // Format: 00:00:00
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    // Call these from other scripts if needed
    public void ToggleTimer(bool state) => _isRunning = state;
    public void ResetTimer() => _timeElapsed = 0;
}