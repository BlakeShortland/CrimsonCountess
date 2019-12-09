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

    void Awake()
    {
        gameController = GameController.Instance;

        myFlame = transform.GetChild(0).gameObject;
        myFlameEmitter = myFlame.GetComponent<ParticleSystem>();
        mySmokeEmitter = myFlame.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
    }

    void Start()
    {
        gameController.candleGrab.AddListener(Extinguish); //Assigns Extinguish function to listen for the candelGrab event
    }

    void Extinguish()
    {
        myFlameEmitter.Stop();
        mySmokeEmitter.Stop();
    }

    public void CandleGrabbed()
    {
        gameController.ExtinguishCandles();
    }
}
