using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public AudioMixer mixer;
    public GameObject controlerPanel;
    public GameObject creditsPanel;
    public GameObject pauseMenu;
    public GameObject settings;
    public Slider MasterVolumeSlider;
    public Slider SoundVolumeSlider;
    public Slider MusicVolumeSlider;


    public void Start()
    {
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SoundVolumeSlider.value = PlayerPrefs.GetFloat("SoundsVolume");
        MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    }
    public void OnDisable()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolumeSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", MasterVolumeSlider.value);
        PlayerPrefs.SetFloat("SoundsVolume", SoundVolumeSlider.value);
    }
    public void StartGame()
    {
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("Game");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ShowControls()
    {
        controlerPanel.SetActive(true);
    }
    public void HideControls()
    {
        controlerPanel.SetActive(false);
    }
    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }
    public void HideCredits()
    {
        creditsPanel.SetActive(false);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void HiddePause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void LoadTitleScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScreen");
    }
    public void ShowSettings()
    {
        settings.SetActive(true);
    }
    public void HideSettings()
    {
        settings.SetActive(false);
    }
   

    public void HandleSliderValueChangedMaster()
    {

        mixer.SetFloat("MasterVolume", MasterVolumeSlider.value);
    }
    public void HandleSliderValueChangedSound()
    {

        mixer.SetFloat("SoundsVolume", SoundVolumeSlider.value);
    }
    public void HandleSliderValueChangedMusic()
    {

        mixer.SetFloat("MusicVolume", MusicVolumeSlider.value);
    }
}
