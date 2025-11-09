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

    [Header("Sounds")]
    [SerializeField] private float soundDetectionRange = 5f;
    [SerializeField] private float soundCooldown = 3f;
    private float soundTimer;
    public Transform player;

    public GameObject damageArea;

    [SerializeField] private Animator animator;
    private string attack = "Anim_Attack_Blue";

    private void Start()
    {
        if (damageArea != null)
        {
            damageArea.SetActive(false);
        }
        StartCoroutine(AttackRoutine());
    }

    private void HandleEnemySounds()
    {
        if (player == null) return;

       
        if (soundTimer > 0f)
            soundTimer -= Time.deltaTime;

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= soundDetectionRange && soundTimer <= 0f)
        {
            AudioManager.Instance.sfxManager.PlayEnemyIdleSound("blue");
            soundTimer = soundCooldown;
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {

            yield return new WaitForSeconds(attackInterval);

            animator.Play(attack);

            if (damageArea != null)
            {
                damageArea.SetActive(true);
            }

            if (waterParticles != null)
            {
                waterParticles.SetActive(true);
                if (player != null)
                {
                    float distance = Vector2.Distance(transform.position, player.position);
                    if (distance <= soundDetectionRange)
                    {
                        AudioManager.Instance.sfxManager.PlayEnemyPower("blue");
                    }
                }

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
