/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.ArtificialBased;

public class WheelchairMovementController : MonoBehaviour
{
    [SerializeField] VRTK_ArtificialRotator leftWheel;
    [SerializeField] VRTK_ArtificialRotator rightWheel;

    //Keeps track of what angle the wheel was in the last frame
    float prevLeftWheelAngle;
    float prevRightWheelAngle;

    //Reprisents the difference in angle between frames divided by the time between frames.
    float leftWheelSpeed;
    float rightWheelSpeed;

    //These values make the wheelchair controllable
    float speedReducer = 0.005f;
    float speedIncreaser = 10f;

    void Start()
    {
        //Set the "previous" rotation values to avoid null references
        prevLeftWheelAngle = leftWheel.GetValue();
        prevRightWheelAngle = rightWheel.GetValue();
    }

    void Update()
    {
        CalculateWheelSpeed();
        Move();
        Rotate();
    }

    void CalculateWheelSpeed()
    {
        //Calculate the speed of each wheel
        leftWheelSpeed = (leftWheel.GetValue() - prevLeftWheelAngle) / Time.deltaTime * speedReducer;
        rightWheelSpeed = (rightWheel.GetValue() - prevRightWheelAngle) / Time.deltaTime * speedReducer;

        //Save the angle of rotation for the next frame's calculation
        prevLeftWheelAngle = leftWheel.GetValue();
        prevRightWheelAngle = rightWheel.GetValue();
    }

    //Determines how fast forwards/backwards to move the wheelchair
    void Move()
    {
        //Forward speed is the average speed of both wheels. This prevents super speed when the wheels are just added together.
        float forwardSpeed = (leftWheelSpeed + rightWheelSpeed) / 2;

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    //Determines which wheel is spinning faster and rotates the wheelchair accordingly
    void Rotate()
    {
        float rotateSpeed = leftWheelSpeed - rightWheelSpeed;

        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * speedIncreaser);
    }
}
