using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    [Header("UI References")]
    public Slider musicSlider;
    public Slider sfxSlider;

    private AudioManager audioManager;

    private void Start()
    {
  
        if (audioManager == null)
        {
            audioManager = FindAnyObjectByType<AudioManager>();
        }

      
        float musicValue = PlayerPrefs.GetFloat("MusicSliderValue", 1f);
        float sfxValue = PlayerPrefs.GetFloat("SFXSliderValue", 1f);

       
        musicSlider.value = musicValue;
        sfxSlider.value = sfxValue;

  
        audioManager.SetMusicVolume(musicValue);
        audioManager.SetSFXVolume(sfxValue);

    
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float volume)
    {
        if (audioManager == null) return;
        audioManager.SetMusicVolume(volume);
        PlayerPrefs.SetFloat("MusicSliderValue", volume);
    }

    public void SetSFXVolume(float volume)
    {
        if (audioManager == null) return;
        audioManager.SetSFXVolume(volume);
        PlayerPrefs.SetFloat("SFXSliderValue", volume);
    }
}
