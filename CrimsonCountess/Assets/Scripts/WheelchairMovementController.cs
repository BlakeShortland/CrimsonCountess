/*
 * Script created by: Blake Shortland | Editor: Joshua Ganon
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK.Controllables.ArtificialBased;
using VRTK;

public class WheelchairMovementController : MonoBehaviour
{
    [SerializeField] VRTK_ArtificialRotator leftWheel;
    [SerializeField] VRTK_ArtificialRotator rightWheel;

    [SerializeField] Transform leftWheelParent;
    [SerializeField] Transform rightWheelParent;

    GameObject leftWheelObj;
    GameObject rightWheelObj;

    [SerializeField] VRTK_InteractGrab leftHandGrab;
    [SerializeField] VRTK_InteractGrab rightHandGrab;

    bool grabbingLeftWheel;
    bool grabbingRightWheel;

    //Keeps track of what angle the wheel was in the last frame
    float prevLeftWheelAngle;
    float prevRightWheelAngle;

    //Reprisents the difference in angle between frames divided by the time between frames.
    float leftWheelSpeed;
    float rightWheelSpeed;

    //These values make the wheelchair controllable
    [SerializeField] float speedReducer = 0.01f;
    [SerializeField] float rotationSpeedIncreaser = 20f;

    float rotationSpeed;

    int straightLineAssist = 0;

    /*enum ControllerTouchingWheel
    {
        Left,
        Right,
        Both,
        None
    }*/

    void Start()
    {
        //Set the "previous" rotation values to avoid null references
        prevLeftWheelAngle = leftWheel.GetValue();
        prevRightWheelAngle = rightWheel.GetValue();

        leftWheelObj = leftWheelParent.GetChild(0).gameObject;
        rightWheelObj = rightWheelParent.GetChild(0).gameObject;

        print(leftWheelObj);
        print(rightWheelObj);
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
        float forwardSpeed = Mathf.Clamp(((leftWheelSpeed + rightWheelSpeed) / 2), -.5f, 1f);

        Vector3 translate = Vector3.back * forwardSpeed * Time.deltaTime;

        transform.Translate(translate);
    }

    //Determines which wheel is spinning faster and rotates the wheelchair accordingly
    void Rotate()
    {
        float rotateSpeed = Mathf.Clamp((StraightLineAssist(leftWheelSpeed, rightWheelSpeed)), -3f, 3f);
        
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * rotationSpeedIncreaser);
    }

    float StraightLineAssist(float leftWheelSpeed, float rightWheelSpeed)
    {
        float rotateSpeed = leftWheelSpeed - rightWheelSpeed;

        if (rotateSpeed < 0.05 && rotateSpeed > -0.05 && BothHandsTouching())
            rotateSpeed = 0;

        rotationSpeed = rotateSpeed;

        return rotateSpeed;
    }

    bool BothHandsTouching()
    {
        if (grabbingLeftWheel && grabbingRightWheel)
            return true;
        else
            return false;
    }

    public void OnLeftHandGrab()
    {
        GameObject obj = leftHandGrab.GetGrabbedObject();

        if (obj != null)
        {
            print("grab" + obj);
            if (obj == leftWheelObj)
            {
                grabbingLeftWheel = true;
            }
            else
            {
                grabbingLeftWheel = false;
            }
        }
    }

    public void OnLeftHandUnGrab()
    {
        GameObject obj = leftHandGrab.GetGrabbedObject();

        if (obj != null)
        {
            print("ungrab" + obj);
            if (obj == leftWheelObj)
            {
                grabbingLeftWheel = false;
            }
        }
    }

    public void OnRightHandGrab()
    {
        GameObject obj = rightHandGrab.GetGrabbedObject();

        if (obj != null)
        {
            print("grab" + obj);
            if (obj == rightWheelObj)
            {
                print("yay righty" + obj);
                grabbingRightWheel = true;
            }
            else
            {
                grabbingRightWheel = false;
            }
        }
    }

    public void OnRightHandUnGrab()
    {
        GameObject obj = rightHandGrab.GetGrabbedObject();

        if (obj != null)
        {
            print("ungrab" + obj);
            if (obj == rightWheelObj)
            {
                grabbingRightWheel = false;
            }
        }
    }

}
