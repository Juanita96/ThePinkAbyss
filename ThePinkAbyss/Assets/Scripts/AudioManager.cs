using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Mixer")]
    public AudioMixer mainMixer;

    [Header("Music Sources")]
    public AudioSource menuMusic;
    public AudioSource gameMusic;

    private string[] menuScenes = { "Menu", "Configuration", "Credits", "Levels Menu" };

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
    }

    void Start()
    {
        float music = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 0f);
        mainMixer.SetFloat("MusicVolume", music);
        mainMixer.SetFloat("SFXVolume", sfx);

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
    }

    public void PlayMenuMusic()
    {
        if (gameMusic.isPlaying) gameMusic.Stop();
        if (!menuMusic.isPlaying)
        {
            menuMusic.loop = true;
            menuMusic.Play();
        }
    }

    public void PlayGameMusic()
    {
        if (menuMusic.isPlaying) menuMusic.Stop();
        if (!gameMusic.isPlaying)
        {
            gameMusic.loop = true;
            gameMusic.Play();
        }
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
