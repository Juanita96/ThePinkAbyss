using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Mixer")]
    public AudioMixer mainMixer;

    [Header("Managers")]
    public SFX sfxManager;

    [Header("Music Sources")]
    public AudioSource menuMusic;
    public AudioSource gameMusic;

    private string[] menuScenes = { "Menu", "Configuration", "Credits", "Levels Menu" };

    private float currentMusicVolume = 1f;
    private float currentSFXVolume = 1f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (sfxManager == null)
            sfxManager = GetComponent<SFX>();
    }

    void Start()
    {
        StartCoroutine(InitializeVolumes());
    }

    private IEnumerator InitializeVolumes()
    {
        
        yield return null;

        currentMusicVolume = PlayerPrefs.GetFloat("MusicSliderValue", 1f);
        currentSFXVolume = PlayerPrefs.GetFloat("SFXSliderValue", 1f);

        ApplyMusicVolume(currentMusicVolume);
        ApplySFXVolume(currentSFXVolume);

        PlayMenuMusic();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool isMenuScene = false;
        foreach (var name in menuScenes)
        {
            if (scene.name.Contains(name))
            {
                isMenuScene = true;
                break;
            }
        }

        if (isMenuScene)
            PlayMenuMusic();
        else
            PlayGameMusic();

      
        ApplyMusicVolume(currentMusicVolume);
        ApplySFXVolume(currentSFXVolume);
    }

    public void PlayMenuMusic()
    {
        if (gameMusic.isPlaying) gameMusic.Stop();
        if (!menuMusic.isPlaying)
        {
            menuMusic.loop = true;
            menuMusic.volume = currentMusicVolume; 
            menuMusic.Play();
        }
    }

    public void PlayGameMusic()
    {
        if (menuMusic.isPlaying) menuMusic.Stop();
        if (!gameMusic.isPlaying)
        {
            gameMusic.loop = true;
            gameMusic.volume = currentMusicVolume; 
            gameMusic.Play();
        }
    }

    public void SetMusicVolume(float value)
    {
        currentMusicVolume = value;
        ApplyMusicVolume(value);
        PlayerPrefs.SetFloat("MusicSliderValue", value);
    }

    public void SetSFXVolume(float value)
    {
        currentSFXVolume = value;
        ApplySFXVolume(value);
        PlayerPrefs.SetFloat("SFXSliderValue", value);
    }

    private void ApplyMusicVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        mainMixer.SetFloat("MusicVolume", dB);
        if (menuMusic.isPlaying) menuMusic.volume = value;
        if (gameMusic.isPlaying) gameMusic.volume = value;
    }

    private void ApplySFXVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        mainMixer.SetFloat("SFXVolume", dB);
    }

    public void ApplyTemporaryMusicVolume(float multiplier)
    {
        float tempVolume = Mathf.Clamp01(currentMusicVolume * multiplier);
        ApplyMusicVolume(tempVolume);
    }

    public void RestoreMusicVolume()
    {
        ApplyMusicVolume(currentMusicVolume);
    }

    public float GetSFXVolume()
    {
        return currentSFXVolume;
    }
}
