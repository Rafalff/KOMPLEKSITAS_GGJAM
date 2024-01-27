using System;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance;
	public Sound[] musicSounds, sfxSounds;
	public AudioSource musicSource, sfxSource;
	// Start is called before the first frame update
	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			if (Instance != this)
			{
				Destroy(gameObject);
			}
		}
	}
	public void StopMusic()
	{
		musicSource.Stop();
	}


	public void PlayMusic(SoundName name)
	{
		Sound s = Array.Find(musicSounds, sound => sound.soundName == name);
		if (s != null)
		{
			musicSource.clip = s.clip;
			musicSource.Play();
		}

	}
	// Update is called once per framecc
	public void PlaySfx(SoundName name)
	{

		Sound s = Array.Find(sfxSounds, sound => sound.soundName == name);
		if (s != null)
		{
			sfxSource.PlayOneShot(s.clip);
		}
	}
	public void PlaySfx(Sound sound)
	{

		if (sound != null)
		{
			sfxSource.PlayOneShot(sound.clip);
		}
	}
	public void PlaySfx(Sound[] randomSound)
	{

		if (randomSound != null)
		{
			sfxSource.PlayOneShot(randomSound[UnityEngine.Random.Range(0, randomSound.Length)].clip);
		}
	}
	public void PlaySfx(SoundName[] randomName)
	{
		SoundName name = randomName[UnityEngine.Random.Range(0, randomName.Length)];
		Sound s = Array.Find(sfxSounds, sound => sound.soundName == name);
		if (s != null)
		{
			sfxSource.PlayOneShot(s.clip);
		}
	}
	public void SetSfxVolume(float volume)
	{
		sfxSource.volume = volume;
	}
	public void SetMusicVolume(float volume)
	{
		musicSource.volume = volume;
	}
}

