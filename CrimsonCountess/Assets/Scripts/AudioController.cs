using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	public AudioSource musicPlayer;
	public AudioSource atmosphericSFX;

	public static AudioController Instance = null;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	public void PlayMusic(AudioClip clip)
	{
		musicPlayer.clip = clip;
		musicPlayer.Play();
	}

	public void PlaySFX(AudioClip clip)
	{
		atmosphericSFX.clip = clip;
		atmosphericSFX.Play();
	}

	public void PlaySFX(AudioClip clip, AudioSource source)
	{
		source.clip = clip;
		source.Play();
	}

	public void StopMusic()
	{
		musicPlayer.Stop();
	}

	public void StopSFX()
	{
		atmosphericSFX.Stop();
	}
}

