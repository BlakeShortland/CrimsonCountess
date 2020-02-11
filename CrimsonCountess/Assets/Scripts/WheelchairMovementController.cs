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
	public VRTK_ControllerEvents controllerEvents;

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

	[SerializeField] float touchpadTouchRecentlyTime = 5;
	float touchpadTouchTimer = 0;

    /*enum ControllerTouchingWheel
    {
        Left,
        Right,
        Both,
        None
    }*/

	public enum WheelchairTypes
	{
		Manual,
		Electric
	}

	WheelchairTypes wheelchairType = WheelchairTypes.Manual;

	void Awake()
	{
		controllerEvents = (controllerEvents == null ? GetComponent<VRTK_ControllerEvents>() : controllerEvents);
		if (controllerEvents == null)
		{
			VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "WheelchairMovementController", "VRTK_ControllerEvents", "the same"));
			return;
		}

		controllerEvents.ButtonTwoPressed += DoButtonTwoPressed;
	}

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
		switch (wheelchairType)
		{
			case WheelchairTypes.Manual:
				CalculateWheelSpeed();
				MoveManual();
				RotateManual();
				break;

			case WheelchairTypes.Electric:
				if(touchpadTouchTimer > 0)
					MoveElectric();
				break;
		}

		if (controllerEvents.touchpadTouched)
			touchpadTouchTimer = touchpadTouchRecentlyTime;

		touchpadTouchTimer -= Time.deltaTime;
	}

	#region ManualWheelchair

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
    void MoveManual()
    {
        //Forward speed is the average speed of both wheels. This prevents super speed when the wheels are just added together.
        float forwardSpeed = Mathf.Clamp(((leftWheelSpeed + rightWheelSpeed) / 2), -.5f, 1f);

        Vector3 translate = Vector3.back * forwardSpeed * Time.deltaTime;

        transform.Translate(translate);
    }

    //Determines which wheel is spinning faster and rotates the wheelchair accordingly
    void RotateManual()
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

	#endregion

	#region ElectricWheelchair

	void MoveElectric()
	{
		Vector2 touchpadPosition = controllerEvents.GetTouchpadAxis();

		float forwardSpeed = Mathf.Clamp(touchpadPosition.y, -.5f, 1f);
		Vector3 translate = Vector3.back * forwardSpeed * Time.deltaTime;
		transform.Translate(translate);

		float rotateSpeed = Mathf.Clamp(touchpadPosition.x * 3, -3f, 3f);
		transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * rotationSpeedIncreaser);
	}

	#endregion

	void DoButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
	{
		if (e.controllerReference.scriptAlias.name == "LeftControllerScriptAlias")
		{
			if (wheelchairType == WheelchairTypes.Manual)
			{
				wheelchairType = WheelchairTypes.Electric;
				Debug.Log("Switched control methods to electric");
			}

			if (wheelchairType == WheelchairTypes.Electric)
			{
				wheelchairType = WheelchairTypes.Manual;
				Debug.Log("Switched control methods to manual");
			}
		}
	}
}
