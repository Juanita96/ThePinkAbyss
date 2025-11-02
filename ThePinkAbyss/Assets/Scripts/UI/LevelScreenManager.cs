using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class LevelUI
{
    public GameObject levelButton;
    public GameObject candyGroup1; 
    public GameObject candyGroup2; 
    public GameObject candyGroup3; 
}


public class LevelScreenManager : MonoBehaviour
{
    [Header("Grupos de botones")]
    public GameObject group1; 
    public GameObject group2; 

    [Header("Flechas")]
    public Button rightArrow;
    public Button leftArrow;

    [Header("Niveles")]
    public List<LevelUI> levelsUI = new List<LevelUI>();

    [Header("Contador general de caramelos")]
    public TMP_Text totalCandiesText;

    private void Start()
    {
        
        rightArrow.onClick.AddListener(ShowGroup2);
        leftArrow.onClick.AddListener(ShowGroup1);

        leftArrow.gameObject.SetActive(false); 
        rightArrow.gameObject.SetActive(true);

        UpdateAllLevels();
        UpdateTotalCandies();
    }

    private void ShowGroup2()
    {
        group1.SetActive(false);
        group2.SetActive(true);

        rightArrow.gameObject.SetActive(false);
        leftArrow.gameObject.SetActive(true);

        UpdateAllLevels();
    }

    private void ShowGroup1()
    {
        group1.SetActive(true);
        group2.SetActive(false);

        rightArrow.gameObject.SetActive(true);
        leftArrow.gameObject.SetActive(false);

        UpdateAllLevels();
    }

    private void UpdateAllLevels()
    {
        for (int i = 0; i < levelsUI.Count; i++)
        {
            int candies = 0;

            if (Active_Levels.instance != null) candies = Active_Levels.instance.GetCandies(i);

            if (levelsUI[i].candyGroup1 != null) levelsUI[i].candyGroup1.SetActive(false);
            if (levelsUI[i].candyGroup2 != null) levelsUI[i].candyGroup2.SetActive(false);
            if (levelsUI[i].candyGroup3 != null) levelsUI[i].candyGroup3.SetActive(false);

            if (candies == 1 && levelsUI[i].candyGroup1 != null) levelsUI[i].candyGroup1.SetActive(true);
            else if (candies == 2 && levelsUI[i].candyGroup2 != null) levelsUI[i].candyGroup2.SetActive(true);
            else if (candies >= 3 && levelsUI[i].candyGroup3 != null) levelsUI[i].candyGroup3.SetActive(true);
        }
    }


    private void UpdateTotalCandies()
    {
        int total = 0;
        if (Active_Levels.instance != null)
        {
            for (int i = 0; i < Active_Levels.instance.levels.Count; i++)
            {
                total += Active_Levels.instance.levels[i].candiesCollected;
            }
        }

        if (totalCandiesText != null)
            totalCandiesText.text = total.ToString("00");
    }


    public void RefreshScreen()
    {
        UpdateAllLevels();
        UpdateTotalCandies();
    }
}
