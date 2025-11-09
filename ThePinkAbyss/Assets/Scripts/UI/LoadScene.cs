using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private SFX sfx;

    private void Awake()
    {
    
        if (AudioManager.Instance != null)
        {
            sfx = AudioManager.Instance.sfxManager;
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1f;
    }

    public void PlayClick()
    {
        if (sfx != null) sfx.PlayUIClick();
    }

    public void PlayHover()
    {
        if (sfx != null) sfx.PlayUIHover();
    }

    public void PlayPlay()
    {
        if (sfx != null) sfx.PlayUIPlay();
    }

}
