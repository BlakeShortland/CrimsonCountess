/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /* 
     * Things that need storing:
     *      AudioManager script (Will control ambiant audio and piano)
     *      SceneManager script (Will control additave/subtractive scene loading)
    */

    enum Rooms {RitualRoom, Bathroom, LivingRoom, Library}
    enum RitualSiteItems {Candle, Knife, Book};

    void Awake()
    {
        
    }

    void Start()
    {
        UnlockRoom(Rooms.Bathroom);
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

    void ExtinguishCandles()
    {
        //Get all candles in bathroom scene
        //Run their extinguish function
        //unlock living room
    }

    void CandleLit()
    {
        //lock bathroom
        //light ritual candle
    }

    void KnifePickedUp()
    {

    }

    void PaintingCut()
    {

    }

    void KeyPickedUp()
    {

    }

    void BookUnlocked()
    {

    }

    void BookGrabbed()
    {

    }

    void RitualCompleted()
    {

    }

    #endregion
}
