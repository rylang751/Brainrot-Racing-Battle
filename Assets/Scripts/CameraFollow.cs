using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothTime = 0.3f; // About how many seconds it takes to catch up
    private Vector3 _currentVelocity = Vector3.zero;

    void LateUpdate()
    {

    if (target == null) return;

    // Direct assignment = Zero delay
    // target.rotation * offset ensures it stays behind the player's back
    transform.position = target.position + (target.rotation * offset);

    transform.LookAt(target);
    }
}