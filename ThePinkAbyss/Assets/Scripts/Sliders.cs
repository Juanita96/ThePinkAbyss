using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioManager audioManager;

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float volume)
    {
        audioManager.SetMusicVolume(volume);
    }
    public void SetSFXVolume(float volume)
    {
        audioManager.SetSFXVolume(volume);
    }


}
