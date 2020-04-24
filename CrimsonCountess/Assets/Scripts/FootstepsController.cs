using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsController : MonoBehaviour
{
	AudioSource audioSource;

	public AudioClip[] creaks;
	public AudioClip[] footSteps;

    void Start()
    {
		audioSource = GetComponent<AudioSource>();

		StartCoroutine(PlayRandomFootsteps());
    }

    IEnumerator PlayRandomFootsteps()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(20f, 60f));

			//Play footsteps
			if (Random.value >= 0.5f)
			{
				PlayAudioClip(footSteps[Random.Range(0, footSteps.Length)]);
				yield return new WaitForSeconds(0.3f);
				PlayAudioClip(footSteps[Random.Range(0, footSteps.Length)]);
			}
			//Play creaks
			else
			{
				PlayAudioClip(creaks[Random.Range(0, creaks.Length)]);
			}
		}
	}

	void PlayAudioClip(AudioClip clip)
	{
		audioSource.clip = clip;
		audioSource.Play();
	}
}
