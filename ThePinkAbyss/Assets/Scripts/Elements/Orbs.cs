using UnityEngine;

public class Orbs : MonoBehaviour
{

    public int orbsCollected = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Orb"))
        {
            other.gameObject.SetActive(false);
            orbsCollected++;
        }
    }


}
