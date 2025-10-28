using UnityEngine;

public class DealDamageBlue : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private string orangeEnemy = "OrangeEnemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(orangeEnemy))
        {
            EnemyHealth enemy = collision.GetComponentInParent<EnemyHealth>();

            enemy.enemyHealth -= damage;

            Debug.Log("Hiciste daño crack");
        }
    }
}
