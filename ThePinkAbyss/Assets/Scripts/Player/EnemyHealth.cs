using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] public int enemyHealth = 3;

    [SerializeField] private GameObject enemy;

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(enemy);
        }
    }
}
