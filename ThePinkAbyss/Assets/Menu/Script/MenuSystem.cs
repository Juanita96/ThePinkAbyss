using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSystem : MonoBehaviour
{
    public void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Menu Loaded");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Menu Closed");
    }
}
