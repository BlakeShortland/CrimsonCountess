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

	float lowerPos = -5f;
	float moveSpeed = 1f;
	float yStart;

	bool move = false;

    void Start()
    {
		audioController = AudioController.Instance;
		gameController = GameController.Instance;
		yStart = transform.localPosition.y;
	}

	void Update()
	{
		if(move)
			lowerAltar();
	}

	public void LowerAltar()
	{
		move = true;
		headsetFade.Fade(Color.black, 5f);
		myAudioSource.Play();
	}

	void lowerAltar()
	{
		if(transform.position.y > lowerPos)
		{
			float y = Mathf.Lerp(yStart, lowerPos, Time.deltaTime * moveSpeed);

			transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
		}
		else
		{
			myAudioSource.Stop();
			audioController.PlaySFX(scream);
			gameController.ReturnToMainMenuDelayed(3f);
			move = false;
		}
	}
}
