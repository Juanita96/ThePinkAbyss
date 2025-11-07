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
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pauseMenu != null)
            pauseMenu.SetActive(true);

        if (pausedTimerText != null && timerText != null)
            pausedTimerText.text = timerText.text;
    }

    public void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ConfigMenu()
    {
        if (configMenu != null)
            configMenu.SetActive(true);
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }

    public void GoBack()
    {
        if (configMenu != null)
            configMenu.SetActive(false);
        if (pauseMenu != null)
            pauseMenu.SetActive(true);
    }
}
