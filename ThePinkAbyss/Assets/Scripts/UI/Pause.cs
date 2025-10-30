using UnityEngine;

public class Pause : MonoBehaviour
{
   
    [Header("Referencias UI")]
    
    public GameObject pauseMenu;
    public bool isPaused = false;


    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pauseMenu != null) pauseMenu.SetActive(false);
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pauseMenu != null) pauseMenu.SetActive(true);
    }

}


