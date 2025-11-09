using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using System.Collections;

public class OrangeEnemy_Controller : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float moveRange = 3.0f;

    [Header("Detection Range")]
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private Transform player;

    [Header("Fire Attack Settings")]
    [SerializeField] private GameObject fireEffect;
    [SerializeField] private float fireDuration = 2.0f;
    [SerializeField] private float fireCooldown = 3.0f;

    [Header("Stats")]
    [SerializeField] public bool isChasing = false;
    [SerializeField] public bool fireActive = false;

    [Header("Sounds")]
    [SerializeField] private float soundDetectionRange = 5f;
    [SerializeField] private float soundCooldown = 3f;
    private float soundTimer;

    private Vector2 startPos;
    private bool movingRight = true;
    private Rigidbody2D rigidBody;
    private float fireTimer = 0f;
    [SerializeField] private PowerPlayers powerPlayers;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        fireEffect.SetActive(false);
    }

    private void Update()
    {
            if (!isChasing)
            {
                Patrol();
            }
            else
            {
                if (!powerPlayers.isOrangeVisible)
                {
                    ChasePlayer();
                }
            }

            DetectPlayer();
            HandleEnemySounds();

        if (fireTimer > 0)
            {
                fireTimer -= Time.deltaTime;
            }
    }

    private void Patrol()
    {
        float distance = transform.position.x - startPos.x;

        if (movingRight)
        {
            rigidBody.linearVelocity = new Vector2(moveSpeed, rigidBody.linearVelocity.y);
        }
        else
        {
            rigidBody.linearVelocity = new Vector2(-moveSpeed, rigidBody.linearVelocity.y);
        }

        if (movingRight && distance >= moveRange)
        {
            movingRight = false;
        }
        else if (!movingRight && distance <= -moveRange)
        {
            movingRight = true;
        }
    }

    private void DetectPlayer()
    {
        if (player == null)
        {
            return;
        }

        float dist = Vector2.Distance(transform.position, player.position);
        isChasing = dist <= detectionRange;
    }

    private void ChasePlayer()
    {
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        rigidBody.linearVelocity = new Vector2(direction * moveSpeed * 1.5f, rigidBody.linearVelocity.y);

        if (!fireActive && fireTimer <= 0)
        {
            if (player != null)
            {
                float distance = Vector2.Distance(transform.position, player.position);
                if (distance <= soundDetectionRange)
                {
                    AudioManager.Instance.sfxManager.PlayEnemyPower("orange");
                }
            }

            StartCoroutine(ActiveFire());
            fireTimer = fireCooldown;
        }
    }

    IEnumerator ActiveFire()
    {
        fireActive = true;
        fireEffect.SetActive(true);

        yield return new WaitForSeconds(fireDuration);

        fireEffect.SetActive(false);
        fireActive = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (fireActive || collision.collider.CompareTag("Fire"))
            {
                Debug.Log("Jugador murió por fuego");
            }
        }
    }

    private void HandleEnemySounds()
    {
        if (player == null)
            return;

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= soundDetectionRange)
        {
            if (soundTimer > 0)
            {
                soundTimer -= Time.deltaTime;
                return;
            }


            AudioManager.Instance.sfxManager.PlayEnemyIdleSound("orange");

            soundTimer = soundCooldown;
        }
    }


}
