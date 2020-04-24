using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRTK;

public class InGameUI : MonoBehaviour
{
	public GameObject mainMenuCanvas;
	public VRTK_ControllerEvents controllerEvents;

	public void Start()
	{
		controllerEvents = (controllerEvents == null ? GetComponent<VRTK_ControllerEvents>() : controllerEvents);
		if (controllerEvents == null)
		{
			VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "WheelchairMovementController", "VRTK_ControllerEvents", "the same"));
			return;
		}

		controllerEvents.ButtonTwoPressed += DoButtonTwoPressed;
	}

	public void ReturnToMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	void ToggleMenu()
	{
		if (mainMenuCanvas.activeInHierarchy)
			HideMenu();
		else
			ShowMenu();
	}

	void ShowMenu()
	{
		mainMenuCanvas.SetActive(true);
	}

	void HideMenu()
	{
		mainMenuCanvas.SetActive(false);
	}

	void DoButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
	{
		if (e.controllerReference.scriptAlias.name == "RightControllerScriptAlias")
		{
			ToggleMenu();
		}
	}
}
