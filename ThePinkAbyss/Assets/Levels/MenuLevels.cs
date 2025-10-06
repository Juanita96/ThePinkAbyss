using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class MenuLevels : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public Transform levelButtonContainer;
    public int totalLevels = 20; // Total number of levels

    void Start()
    {
        GenerateLevelButtons();
    }

    void GenerateLevelButtons()
    {
        for (int i = 1; i <= totalLevels; i++)
        {
            GameObject buttonObj = Instantiate(levelButtonPrefab, levelButtonContainer);
            buttonObj.GetComponentInChildren<TextMesh>().text = "Level " + i;

            int levelIndex = i; // Capture the current value of i
            buttonObj.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => 
            {
                SceneManager.LoadScene("Level" + levelIndex);
            });

        }
    }
}
