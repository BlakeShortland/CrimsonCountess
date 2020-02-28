/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using UnityEngine;
using Aura2API;

public class CeilingLightController : MonoBehaviour
{
	Light myLight;
	AuraLight auraLight;
	GameController gameController;

	void Start()
	{
		gameController = GameController.instance;
		auraLight = GetComponent<AuraLight>();
		myLight = GetComponent<Light>();
		gameController.candleGrab.AddListener(DisableLight);
		gameController.candlePlace.AddListener(EnableLight);
	}

	public void EnableLight()
	{
		auraLight.enabled = true;
		myLight.enabled = true;
	}

	public void DisableLight()
	{
		auraLight.enabled = false;
		myLight.enabled = false;
	}
}
