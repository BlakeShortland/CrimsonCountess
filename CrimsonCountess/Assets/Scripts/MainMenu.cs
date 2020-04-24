using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
	{
		StartCoroutine(LoadAsyncScene());
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	IEnumerator LoadAsyncScene()
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GreyboxLevel");

		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}
