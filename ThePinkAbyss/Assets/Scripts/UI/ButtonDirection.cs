using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [Header("Escena y Sprites")]
    public string sceneName;
    public Sprite unlockedSprite;
    public Sprite lockedSprite;

    [Header("Número de nivel")]
    public int levelNumber;

    [Header("Opcionales")]
    public TMP_Text buttonText; 

    private Button button;
    private Image buttonImage;

    private void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        if (Active_Levels.instance == null)
        {
            Debug.LogWarning("No se encontró Active_Levels en la escena");
            SetLocked();
            return;
        }

        bool isActive = Active_Levels.instance.LevelActive(levelNumber);

        if (isActive)
            SetUnlocked();
        else
            SetLocked();
    }

    private void SetUnlocked()
    {
        button.interactable = true;
        if (buttonImage != null && unlockedSprite != null)
            buttonImage.sprite = unlockedSprite;

        if (buttonText != null)
            buttonText.gameObject.SetActive(true);
    }

    private void SetLocked()
    {
        button.interactable = false;
        if (buttonImage != null && lockedSprite != null)
            buttonImage.sprite = lockedSprite;
            buttonImage.color = Color.white;

        if (buttonText != null)
            buttonText.gameObject.SetActive(false); 
    }

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
            SceneManager.LoadScene(sceneName);
    }
}
