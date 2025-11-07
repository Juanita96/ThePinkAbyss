using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause : MonoBehaviour
{
   
    [Header("Referencias UI")]
    
    public GameObject pauseMenu;
    public TMP_Text timerText;
    public TMP_Text pausedTimerText;
    public GameObject configMenu;

    public bool isPaused = false;
    

    private void Start()
    {
        if (pauseMenu != null)
            pauseMenu.gameObject.SetActive(false);
    }


    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (AudioManager.Instance != null)
            AudioManager.Instance.SetMusicVolume(1f);
        if (pauseMenu != null) pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pauseMenu != null) pauseMenu.SetActive(true);
        pausedTimerText.text = timerText.text;
        if (AudioManager.Instance != null)
            AudioManager.Instance.SetMusicVolume(0.2f);
    }

    public void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void ConfigMenu()
    {
        if (configMenu != null) configMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void GoBack()
    {
        if(configMenu != null) configMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

}


