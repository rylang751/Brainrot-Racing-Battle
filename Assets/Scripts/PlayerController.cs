using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float turnSpeed = 100f;

    void Update()
    {
        // 1. Get Inputs
        float moveInput = Input.GetAxis("Vertical");   // W/S or Up/Down
        float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right

        // 2. Move Forward/Backward
        // We use transform.forward so it moves in the direction the nose is pointing
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // 3. Rotate Left/Right
        // Only allow turning if the car is actually moving (optional but more realistic)
        if (moveInput != 0)
        {
            // Reverse the turn direction if moving backward
            float direction = moveInput > 0 ? 1 : -1;
            transform.Rotate(Vector3.up, turnInput * turnSpeed * direction * Time.deltaTime);
        }
    }
}
