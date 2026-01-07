using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Drag your 3D object here
    public Vector3 offset;    // Adjust this in the Inspector (e.g., 0, 5, -10)
    public float smoothSpeed = 0.125f;



    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        // Smoothly move from current position to desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.LookAt(target); // Keep the object in the center
    }
}
