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

    float prevLeftWheelAngle;
    float prevRightWheelAngle;

    float leftWheelSpeed;
    float rightWheelSpeed;

    float rotationSmoothing = 5f;
    float speedReducer = 0.005f;
    float speedIncreaser = 10f;

    void Start()
    {
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
        leftWheelSpeed = (leftWheel.GetValue() - prevLeftWheelAngle) / Time.deltaTime * speedReducer;
        rightWheelSpeed = (rightWheel.GetValue() - prevRightWheelAngle) / Time.deltaTime * speedReducer;

        prevLeftWheelAngle = leftWheel.GetValue();
        prevRightWheelAngle = rightWheel.GetValue();
    }

    void Move()
    {
        float forwardSpeed = (leftWheelSpeed + rightWheelSpeed) / 2;

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        float rotateSpeed = leftWheelSpeed - rightWheelSpeed;

        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * speedIncreaser);
    }
}
