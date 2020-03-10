using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	public ccAudioClip[] ccAudioClips;

	AudioSource musicPlayer;

	void Awake()
	{
		musicPlayer = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
	}

	void Start()
	{
		
	}

	void PlaySound(string soundName)
	{
		foreach(ccAudioClip ccAudioClip in ccAudioClips)
		{
			if(ccAudioClip.audioClipName == soundName)
			{
				if(ccAudioClip.audioSourceTransform == null)
				{
					musicPlayer.clip = ccAudioClip.audioClip;
					musicPlayer.Play();
				}
			}
		}
	}
}

[System.Serializable]
public class ccAudioClip
{
	[Tooltip("The audio clip")]
	public AudioClip audioClip;
	[Tooltip("The title of audio clip")]
	public string audioClipName;
	[Tooltip("The description of audio clip")]
	public string audioClipDescription;
	[Tooltip("The source transform of the sound. If blank, it will be a global 2D sound (eg Music, Rain)")]
	public Transform audioSourceTransform;
}
