using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 3, -7); // Typical Kart offset
    public float smoothTime = 0.15f; // Lower = tighter, Higher = floatier
    
    private Vector3 _currentVelocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        // 1. Calculate the target position based on the player's current rotation
        // This ensures the camera stays behind the kart's local 'back'
        Vector3 targetPosition = target.position + (target.rotation * offset);

        // 2. Smoothly move the camera to that position
        // SmoothDamp handles the 'acceleration' and 'deceleration' of the camera movement
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);

        // 3. Look at the player (or slightly above/ahead of them)
        transform.LookAt(target.position + target.up); 
    }
}