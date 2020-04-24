using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
	public GameObject mainMenuCanvas;

    public void ReturnToMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void ToggleMenu()
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
}
