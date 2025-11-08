using UnityEngine;

public class Lamp : MonoBehaviour
{

    public GameObject LampLight;

    private Vector3 originalScale;
    private float scaleMultiplier = 1.2f;

    private void Start()
    {
        originalScale = transform.localScale;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerFire"))
        {
            LampLight.SetActive(true);
        }
        else if (other.CompareTag("Player"))
        {
            transform.localScale = originalScale * scaleMultiplier;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.localScale = originalScale;
        }
    }

}
