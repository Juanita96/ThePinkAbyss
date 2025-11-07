using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damageCooldown = 1f;
    [SerializeField] private float timeToDamage = 0.5f;
    private bool canDamage = true;

    private float timeInside = 0f;
    private PlayerHurt currentPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentPlayer = other.GetComponent<PlayerHurt>() ?? other.GetComponentInParent<PlayerHurt>();
            timeInside = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!canDamage || currentPlayer == null)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            timeInside += Time.deltaTime;

            if (timeInside >= timeToDamage)
            {
                currentPlayer.TakeDamage();
                StartCoroutine(DamageCooldown());
                timeInside = 0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentPlayer = null;
            timeInside = 0f;
        }

    }
    private IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}
