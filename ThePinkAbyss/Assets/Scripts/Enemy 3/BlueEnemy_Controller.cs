using UnityEngine;
using System.Collections;

public class BlueEnemy_Controller : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject waterParticles;
    public float attackInterval = 3f;
    public float damageDuration = 1f;

    [Header("Damage Settings")]
    public int damageToPlayer = 1;

    public GameObject damageArea;

    private void Start()
    {
        if (damageArea != null)
        {
            damageArea.SetActive(false);
        }
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);

            
            if (damageArea != null)
            {
                damageArea.SetActive(true);
            }

            if (waterParticles != null)
            {
                waterParticles.SetActive(true);
            }

            yield return new WaitForSeconds(damageDuration);

            
            if (damageArea != null)
            {
                damageArea.SetActive(false);
            }

            if (waterParticles != null)
            {
                waterParticles.SetActive(false);
            }
        }
    }
}
