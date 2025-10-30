using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerController player;

    private Vector3 originalScale;
    private float scaleMultiplier = 1.2f;

    private void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerController>();
        }

        originalScale = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.lives -= 1;
            transform.localScale = originalScale * scaleMultiplier;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.localScale = originalScale;
        }
    }

}
