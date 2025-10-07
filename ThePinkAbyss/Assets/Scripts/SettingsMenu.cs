using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        float musicDB = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float sfxDB = PlayerPrefs.GetFloat("SFXVolume", 0f);
        musicSlider.value = Mathf.Pow(10f, musicDB / 20f);
        sfxSlider.value = Mathf.Pow(10f, sfxDB / 20f);
    }

    public void OnMusicChange(float value)
    {
        AudioManager.Instance.SetMusicVolume(value);
    }

    public void OnSFXChange(float value)
    {
        AudioManager.Instance.SetSFXVolume(value);
    }
}
