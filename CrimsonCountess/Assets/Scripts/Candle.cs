/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    GameController gameController;

    GameObject myFlame; //A reference to the flame gameobject
    ParticleSystem myFlameEmitter;
    ParticleSystem mySmokeEmitter;
    GameObject myLight;

    void Awake()
    {
        myFlame = transform.GetChild(0).gameObject;
        myFlameEmitter = myFlame.GetComponent<ParticleSystem>();
        mySmokeEmitter = myFlame.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        myLight = myFlame.transform.GetChild(0).gameObject;
    }

    void Start()
    {
        gameController = GameController.instance;
        gameController.candleGrab.AddListener(Extinguish); //Assigns Extinguish function to listen for the candelGrab event
    }

    void Extinguish()
    {
        myFlameEmitter.Stop();
        mySmokeEmitter.Stop();
        myLight.SetActive(false);
    }

    public void CandleGrabbed()
    {
        gameController.ExtinguishCandles();
    }
}
