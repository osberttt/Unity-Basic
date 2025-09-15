using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip musicClip;

    private void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }
}
