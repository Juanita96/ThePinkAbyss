using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryScreen : MonoBehaviour
{

    public GameObject victoryScreen;
    public GameObject candy1;
    public GameObject candy2;
    public GameObject candy3;
    public TMP_Text timer;
    public TMP_Text finalTime;
    public HUD hud;


    private void Start()
    {
        victoryScreen.SetActive(false);  
        hud = FindAnyObjectByType<HUD>();
    }

    public void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
        finalTime.text = timer.text;
        FinalCandies();
        UpdateCandies();
    }

    private void FinalCandies()
    {
        if (candy1 != null && candy2 != null && candy3 != null)
        {
            candy1.SetActive(hud.candiesCollected >= 1);
            candy2.SetActive(hud.candiesCollected >= 2);
            candy3.SetActive(hud.candiesCollected == 3);
        }
    }

    private void UpdateCandies()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex - 1;
        int currentCandies = Active_Levels.instance.GetCandies(currentLevelIndex);
        
        if (Active_Levels.instance != null && hud.candiesCollected > currentCandies)
        {
            Active_Levels.instance.SetCandies(currentLevelIndex, hud.candiesCollected);
            Active_Levels.instance.UnlockLevel(currentLevelIndex + 1);
        }
            
    }

}
