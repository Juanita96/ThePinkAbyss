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
            GameObject button = Instantiate(levelButtonPrefab, levelButtonContainer);
            button.GetComponentInChildren<TextMesh>().text = "Level " + i; //se supone que esta hecho con TextMeshPro pero no me deja usarlo

            int levelIndex = i; // Capture the current value of i
            button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => 
            {
                SceneManager.LoadScene("Level" + levelIndex);
            });

        }
    }
}
