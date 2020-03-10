/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using UnityEngine;
using Aura2API;

public class FogController : MonoBehaviour
{
	AuraVolume auraVolume;
	GameController gameController;

	void Start()
	{
		gameController = GameController.instance;
		auraVolume = GetComponent<AuraVolume>();
		gameController.candleGrab.AddListener(EnableFog);
		gameController.candlePlace.AddListener(DisableFog);
	}

	public void EnableFog()
	{
		auraVolume.enabled = true;
	}

	public void DisableFog()
	{
		auraVolume.enabled = false;
	}
}
