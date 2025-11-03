using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerHurt player;

    private Vector3 originalScale;
    private float scaleMultiplier = 1.2f;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerHurt>();
        originalScale = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage();
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
