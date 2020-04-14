using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	GameController gameController;

	[SerializeField] AudioClip[] musicClips;
	[SerializeField] AudioClip[] atmosphericSFXClips;
	[SerializeField] AudioClip[] weatherClips;
	[SerializeField] AudioClip[] miscClips;
	[SerializeField] AudioClip[] heartBeatClips;

	public AudioSource musicPlayer;
	public AudioSource atmosphericSFX;
	public AudioSource thunder;

	public static AudioController Instance = null;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		gameController = GameController.Instance;
	}

	void Start()
	{
		StartCoroutine(LoopThunder());
		StartCoroutine(LoopMusic());
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

	IEnumerator LoopThunder()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(15,180));

			PlaySFX(weatherClips[Random.Range(0, weatherClips.Length - 1)], thunder);
		}
	}

	IEnumerator LoopMusic()
	{
		int i = 0;

		while (true)
		{
			PlayMusic(musicClips[i]);
			i++;

			if (i == musicClips.Length)
				i = 0;

			yield return new WaitUntil(() => !musicPlayer.isPlaying);
		}
	}
}

