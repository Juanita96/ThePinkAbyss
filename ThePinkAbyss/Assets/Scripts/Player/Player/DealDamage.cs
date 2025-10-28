using System.Runtime.CompilerServices;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private PowerPlayers power;

    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(power.blueEnemy) || collision.CompareTag(power.greenEnemy) || collision.CompareTag(power.violetEnemy))
        {
            EnemyHealth enemy = collision.GetComponentInParent<EnemyHealth>();

            enemy.enemyHealth -= damage;

            Debug.Log("Hiciste daño crack");
        }
    }
}
