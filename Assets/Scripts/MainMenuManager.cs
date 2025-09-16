using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public Slider musicSlider;
    public Slider sfxSlider;

    public GameObject optionsPanel;
    
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
