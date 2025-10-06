using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuLevels : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject Button;
    [SerializeField] private int sceneIndex;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
