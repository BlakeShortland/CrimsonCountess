﻿/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    /* 
     * Things that need storing:
     *      AudioManager script (Will control ambiant audio and piano)
     *      SceneManager script (Will control additave/subtractive scene loading)
    */
    
    public static GameController instance { get; private set; }

	#region Bools

	public bool bookPlaced;
	public bool candlePlaced;
	public bool ritualComplete;

	#endregion

	#region Events

	public UnityEvent candleGrab;
	public UnityEvent candlePlace;

	#endregion

	enum Rooms {RitualRoom, Bathroom, LivingRoom, Library}
    enum RitualSiteItems {Candle, Knife, Book};

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        SetUpEvents();
    }

    void Start()
    {
        UnlockRoom(Rooms.Bathroom);
    }

    void Update()
    {
        if (Input.GetKeyDown("g"))
            candleGrab.Invoke();
    }

    #region MultiUseFunctions

    /// <summary>UnlockRoom will unlock the selected room for the player</summary>
    /// <param name="room">Used to specify which room to unlock</param>
    void UnlockRoom(Rooms room)
    {
        switch (room)
        {
            case Rooms.RitualRoom:
                //load ritual room scene
                //open door
                break;

            case Rooms.Bathroom:
                //load bathroom scene
                //open door
                break;

            case Rooms.LivingRoom:
                //load living room scene
                //open door
                break;

            case Rooms.Library:
                //load library scene
                //open door
                break;
        }
    }

    /// <summary>LockRoom will lock the selected room from the player to prevent them from exploring finished areas/puzzles</summary>
    /// <param name="room">Used to specify which room to lock</param>
    void LockRoom(Rooms room)
    {
        switch (room)
        {
            case Rooms.RitualRoom:
                //close door
                //unload ritual room scene
                break;

            case Rooms.Bathroom:
                //close door
                //unload bathroom scene
                break;

            case Rooms.LivingRoom:
                //close door
                //unload living room scene
                break;

            case Rooms.Library:
                //close door
                //unload library scene
                break;
        }
    }

    /// <summary>RitualSiteAdded will make the necisary changes to the scene as objects are added to the ritual site</summary>
    /// <param name="item">Used to specify item added to ritual site</param>
    void RitualSiteAdded(RitualSiteItems item)
    {
        switch(item)
        {
            case RitualSiteItems.Candle:
                //Lock living room
                //Unlock library
                break;

            case RitualSiteItems.Knife:
                break;

            case RitualSiteItems.Book:
                RitualCompleted();
                break;
        }
    }

    void GetSceneControllerInstance(GameObject sceneController)
    {
        
    }

    #endregion

    #region SingleUseFunctions

    void SetUpEvents()
    {
        if (candleGrab == null)
            candleGrab = new UnityEvent();
		if (candlePlace == null)
			candlePlace = new UnityEvent();
	}

    public void ExtinguishCandles()
    {
		if (!candlePlaced)
		{

			//Get all candles in bathroom scene
			//Run their extinguish function
			//Unlock living room

			candleGrab.Invoke(); //Triggers candleGrab event
		}
    }

	public void CandlePlace()
	{
		candlePlaced = true;
		candlePlace.Invoke();
	}

	public void BookPickedUp()
    {

    }

    public void BookPlaced()
    {

    }

	public void KnifePickedUp()
	{

	}

	public void RitualCompleted()
    {

    }

    #endregion
}
