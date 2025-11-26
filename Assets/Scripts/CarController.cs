using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel, frontRightWheel, rearLeftWheel, rearRightWheel;
    public float maxMotorTorque = 1500f;
    public float maxSteeringAngle = 30f;

    private float horizontalInput, verticalInput;

    void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // Get A/D or Left/Right arrow input
        verticalInput = Input.GetAxis("Vertical");     // Get W/S or Up/Down arrow input
    }

    private void HandleMotor()
    {
        // Apply torque to the rear wheels for movement
        rearLeftWheel.motorTorque = verticalInput * maxMotorTorque;
        rearRightWheel.motorTorque = verticalInput * maxMotorTorque;
    }

    private void HandleSteering()
    {
        // Apply steering angle to the front wheels
        frontLeftWheel.steerAngle = horizontalInput * maxSteeringAngle;
        frontRightWheel.steerAngle = horizontalInput * maxSteeringAngle;
    }
    
}
