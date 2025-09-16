using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // singleton pattern, 
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public AudioSource musicSource;
    public GameObject sfxSourcePrefab;

    public AudioClip musicClip;

    public float musicVolume = 0.5f;
    public float sfxVolume = 0.5f;
   
    private void Start()
    {
       //PlayMusic(musicClip);
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        var sfxSource = Instantiate(sfxSourcePrefab);
        var sourceComponent = sfxSource.GetComponent<AudioSource>();
        sourceComponent.volume = sfxVolume;
        sourceComponent.PlayOneShot(sfxClip);
        Destroy(sfxSource, sfxClip.length);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
    }
}

// Instantiate
// prefab