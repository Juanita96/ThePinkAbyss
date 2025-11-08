using UnityEngine;

public class Candies : MonoBehaviour
{
    public CandiesAndOrbsCounter candiesAndOrbsCounter;

    private void Start()
    {
        candiesAndOrbsCounter = FindAnyObjectByType<CandiesAndOrbsCounter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            other.gameObject.SetActive(false);
            candiesAndOrbsCounter.candyCollected++;
            AudioManager.Instance.GetComponent<SFX>().PlayCandyPickup();
        }
    }
}
