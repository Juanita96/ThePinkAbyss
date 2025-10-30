using UnityEngine;

public class Candies : MonoBehaviour
{
    public int candyCollected = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            other.gameObject.SetActive(false);
            candyCollected++;
        }
    }
}
