using UnityEngine;

public class DamageBlue : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                Debug.Log("Moriste Crack");
            }
        }
    }
}
