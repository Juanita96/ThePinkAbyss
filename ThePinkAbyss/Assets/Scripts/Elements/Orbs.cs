using UnityEngine;

public class Orbs : MonoBehaviour
{

    public CandiesAndOrbsCounter candiesAndOrbsCounter;

    private void Start()
    {
        candiesAndOrbsCounter = FindAnyObjectByType<CandiesAndOrbsCounter>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Orb"))
        {
            other.gameObject.SetActive(false);
            candiesAndOrbsCounter.orbsCollected++;
        }
    }


}