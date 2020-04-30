using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class StoneSlab : MonoBehaviour
{
	public AudioSource myAudioSource;
	AudioController audioController;
	GameController gameController;

	public AudioClip scream;

	public VRTK_HeadsetFade headsetFade;
	

    void Start()
    {
		audioController = AudioController.Instance;
		gameController = GameController.Instance;
	}

	public void LowerAltar()
	{
		headsetFade.Fade(Color.black, 5f);
		myAudioSource.Play();
		audioController.PlaySFXDelayed(scream, 2f);
		gameController.ReturnToMainMenuDelayed(8f);
	}
}
