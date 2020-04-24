/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
	AudioController audioController;

	public static GameController Instance = null;

	public bool bookPlaced;
	public bool candlePlaced;
	public bool ritualComplete;

	public UnityEvent candleGrab;
	public UnityEvent candlePlace;
	public UnityEvent bookPickedUp;
	public UnityEvent bookPlace;
	public UnityEvent knifePickedUp;
	public UnityEvent ritualCompleted;

	enum Rooms {RitualRoom, Bathroom, LivingRoom, Library}
    enum RitualSiteItems {Candle, Knife, Book};

	public Renderer elizabethPaintingRenderer;
	public Texture[] paintings = new Texture[4];

	public Material whiteGlow;

	void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

		audioController = AudioController.Instance;

        SetUpEvents();
    }

    void Start()
    {
        UnlockRoom(Rooms.Bathroom);

		elizabethPaintingRenderer.material.mainTexture = paintings[0];
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
		if (bookPickedUp == null)
			bookPickedUp = new UnityEvent();
		if (bookPlace == null)
			bookPlace = new UnityEvent();
		if (knifePickedUp == null)
			knifePickedUp = new UnityEvent();
		if (ritualCompleted == null)
			ritualCompleted = new UnityEvent();
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

		elizabethPaintingRenderer.material.mainTexture = paintings[1];
	}

	public void BookPickedUp()
    {
		bookPickedUp.Invoke();
    }

    public void BookPlaced()
    {
		bookPlaced = true;
		bookPlace.Invoke();

		elizabethPaintingRenderer.material.mainTexture = paintings[2];
	}

	public void KnifePickedUp()
	{
		knifePickedUp.Invoke();
	}

	public void RitualCompleted()
    {
		ritualComplete = true;
		ritualCompleted.Invoke();

		elizabethPaintingRenderer.material.mainTexture = paintings[3];
	}

	public void DisableWhiteGlowEmission()
	{
		whiteGlow.DisableKeyword("_EMISSION");
		whiteGlow.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
		whiteGlow.SetColor("_EmissionColor", Color.black);
	}

	public void EnableWhiteGlowEmission()
	{
		whiteGlow.EnableKeyword("_EMISSION");
		whiteGlow.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
		whiteGlow.SetColor("_EmissionColor", Color.white);
	}

	#endregion
}
