/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using System.Collections;
using UnityEngine;

public class Candle : MonoBehaviour
{
	public GameController gameController;

	public GameObject myFlame; //A reference to the flame gameobject
	public ParticleSystem myFlameEmitter;
	public ParticleSystem mySmokeEmitter;
	public GameObject myLight;

	void Awake()
	{
		
	}

	public virtual void Start()
	{
		gameController = GameController.Instance;
		gameController.candleGrab.AddListener(Extinguish); //Assigns Extinguish function to listen for the candelGrab event
		mySmokeEmitter.Stop();
	}

	public virtual void Extinguish()
	{
		myFlameEmitter.Stop();
		mySmokeEmitter.Play();
		StartCoroutine(StopSmoke(2));
		myLight.SetActive(false);
	}

	public void CandleGrabbed()
	{
		gameController.ExtinguishCandles();
	}

	IEnumerator StopSmoke(int delay)
	{
		yield return new WaitForSeconds(delay);
		mySmokeEmitter.Stop();
	}
}
