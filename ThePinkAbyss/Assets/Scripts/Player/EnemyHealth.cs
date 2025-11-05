using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] public int enemyHealth = 3;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject enemy;

    private string enemyHurt = "Anim_Hurt";

    private string attackHitbox = "AttackHitbox";

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            StartCoroutine(EnemyDeath());
        }
    }

    IEnumerator EnemyDeath()
    {
        animator.Play(enemyHurt);

        yield return new WaitForSeconds(1);

        Destroy(enemy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(attackHitbox))
        {
            animator.Play(enemyHurt);
        }
    }
}
