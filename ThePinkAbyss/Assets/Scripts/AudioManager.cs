using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioMixer mainMixer;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        float music = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 0f);
        mainMixer.SetFloat("MusicVolume", music);
        mainMixer.SetFloat("SFXVolume", sfx);
    }

    public void SetMusicVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        mainMixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolume", dB);
    }

    public void SetSFXVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        mainMixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat("SFXVolume", dB);
    }
}
