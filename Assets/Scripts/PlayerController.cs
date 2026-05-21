using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float turnSpeed = 100f;

    [Header("Out of Bounds Settings")]
    [SerializeField] private LayerMask trackLayer;       
    [SerializeField] private float offTrackBufferTime = 0.5f; 
    [SerializeField] private float positionHistoryRewind = 1.2f; // Increased slightly for safer placement

    [Header("Visual Fade Settings")]
    [SerializeField] private CanvasGroup fadeCanvasGroup; 
    [SerializeField] private float fadeOutSpeed = 0.6f;     // Time it takes to go from clear to black
    [SerializeField] private float holdBlackDuration = 0.5f; // Time spent completely black (hides the snap)
    [SerializeField] private float fadeInSpeed = 0.8f;      // Time it takes to go from black to clear

    private struct PlayerStateSnapshot
    {
        public Vector3 position;
        public Quaternion rotation;
        public float timestamp;

        public PlayerStateSnapshot(Vector3 pos, Quaternion rot, float time)
        {
            position = pos;
            rotation = rot;
            timestamp = time;
        }
    }

    private List<PlayerStateSnapshot> pathHistory = new List<PlayerStateSnapshot>();
    private float offTrackTimer = 0f;
    private bool isOffTrack = false;
    private bool isTeleporting = false; // Lock variable to stop inputs

    void Update()
    {
        // STOP ALL MOVEMENT AND PROCESSING IF WE ARE MID-TELEPORT
        if (isTeleporting) return;

        // 1. Core Movement
        float moveInput = Input.GetAxis("Vertical");   
        float turnInput = Input.GetAxis("Horizontal"); 

        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        if (moveInput != 0)
        {
            float direction = moveInput > 0 ? 1 : -1;
            transform.Rotate(Vector3.up, turnInput * turnSpeed * direction * Time.deltaTime);
        }

        // 2. Track Management
        if (CheckIfOnTrack())
        {
            isOffTrack = false;
            offTrackTimer = 0f;

            pathHistory.Add(new PlayerStateSnapshot(transform.position, transform.rotation, Time.time));

            float oldestAllowedTime = Time.time - positionHistoryRewind - 1f;
            while (pathHistory.Count > 0 && pathHistory[0].timestamp < oldestAllowedTime)
            {
                pathHistory.RemoveAt(0);
            }
        }
        else
        {
            isOffTrack = true;
            offTrackTimer += Time.deltaTime;

            if (offTrackTimer >= offTrackBufferTime)
            {
                // Start the asynchronous fade and teleport sequence
                StartCoroutine(TeleportSequence());
            }
        }
    }

    bool CheckIfOnTrack()
    {
        return Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, 2f, trackLayer);
    }

    // Coroutine handles pacing out the teleport smoothly over time
        IEnumerator TeleportSequence()
    {
        isTeleporting = true;
        offTrackTimer = 0f;
        isOffTrack = false;

        // 1. Fade smoothly to black
        if (fadeCanvasGroup != null)
        {
            float timer = 0;
            while (timer < fadeOutSpeed)
            {
                timer += Time.deltaTime;
                fadeCanvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeOutSpeed);
                yield return null;
            }
            fadeCanvasGroup.alpha = 1f;
        }

        // 2. Clear out player history and move the car while the screen is 100% black
        if (pathHistory.Count > 0)
        {
            float targetTime = Time.time - offTrackBufferTime - positionHistoryRewind;
            PlayerStateSnapshot bestSnapshot = pathHistory[pathHistory.Count - 1];

            for (int i = pathHistory.Count - 1; i >= 0; i--)
            {
                if (pathHistory[i].timestamp <= targetTime)
                {
                    bestSnapshot = pathHistory[i];
                    break;
                }
            }

            transform.position = bestSnapshot.position + Vector3.up * 0.1f;
            transform.rotation = bestSnapshot.rotation;
        }

        pathHistory.Clear();

        // 3. Keep the screen black for a moment so the player's eyes adapt and camera snaps rest
        yield return new WaitForSeconds(holdBlackDuration);

        // 4. Fade slowly back into the game
        if (fadeCanvasGroup != null)
        {
            float timer = 0;
            while (timer < fadeInSpeed)
            {
                timer += Time.deltaTime;
                fadeCanvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeInSpeed);
                yield return null;
            }
            fadeCanvasGroup.alpha = 0f;
        }

        // 5. Release player controls
        isTeleporting = false;
    }

    private void OnDrawGizmos()
    {
        if (isTeleporting) return;
        Gizmos.color = isOffTrack ? Color.red : Color.green;
        Gizmos.DrawRay(transform.position + Vector3.up * 0.5f, Vector3.down * 2f);
    }
}