using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damageCooldown = 1f;
    private bool canDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canDamage) return;

        if (other.CompareTag("Player"))
        {
            PlayerHurt player = other.GetComponent<PlayerHurt>() ?? other.GetComponentInParent<PlayerHurt>();
            if (player != null)
            {
                player.TakeDamage();
                StartCoroutine(DamageCooldown());
            }
        }
    }

    private IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}
