using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public Slider musicSlider;
    public Slider sfxSlider;

    public GameObject optionsPanel;

    private void Start()
    {
        var musicVolume = SaveManager.GetMusicVolume();
        var sfxVolume = SaveManager.GetSfxVolume();
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
    }

    public void Play()
    {
        SceneManager.LoadScene("Platformer");
    }

    public void OptionsOn()
    {
       optionsPanel.SetActive(true);
    }

    public void OptionsOff()
    {
        optionsPanel.SetActive(false);
        SaveManager.SaveMusicVolume(musicSlider.value);
        SaveManager.SaveSfxVolume(sfxSlider.value);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
        AudioManager.Instance.SetSFXVolume(sfxSlider.value);
    }
}
