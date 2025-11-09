using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Splash : MonoBehaviour
{
    public float duration = 3f; 
    public string nextSceneName = "Menu";

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(nextSceneName);
    }
}
