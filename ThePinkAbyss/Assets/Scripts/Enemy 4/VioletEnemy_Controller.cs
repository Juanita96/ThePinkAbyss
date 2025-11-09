using UnityEngine;

public class VioletEnemy_Controller : MonoBehaviour
{
    [Header("Circular Movement")]
    [SerializeField] public float moveRadius = 2f;
    public float rotationSpeed = 1.5f;
    public float returnSpeed = 3f;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private float angle;

    [Header("Detection")]
    [SerializeField] public float detectionRadius = 5f;
    [SerializeField] public float chaseSpeed = 3f;
    private bool isChasing = false;

    [Header("Sounds")]
    [SerializeField] private float soundDetectionRange = 5f;
    [SerializeField] private float soundCooldown = 3f;
    private float soundTimer;

    [SerializeField] private Rigidbody2D rigidBody;
    private PlayerController playerController;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        playerController = FindAnyObjectByType<PlayerController>();
    }

    void OnEnable()
    {
        soundTimer = soundCooldown;
    }


    void FixedUpdate()
    {
        if (playerController != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, playerController.transform.position);
            isChasing = distanceToPlayer <= detectionRadius;

            if (distanceToPlayer <= soundDetectionRange && rigidBody != null)
            {
                HandleEnemySounds(distanceToPlayer);
            }

            if (isChasing)
            {
                ChasePlayer();
            }
            else
            {
                MoveCircular();
            }
        }
        else
        {
            MoveCircular();
        }
    }

    void MoveCircular()
    {
        angle += rotationSpeed * Time.deltaTime;
        Vector2 targetPos = startPos + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * moveRadius;

        Vector2 newPos = Vector2.Lerp(rigidBody.position, targetPos, Time.deltaTime * returnSpeed);
        rigidBody.MovePosition(newPos);
    }

    void ChasePlayer()
    {
        Vector2 dir = (playerController.transform.position - transform.position).normalized;
        Vector2 newPos = rigidBody.position + dir * chaseSpeed * Time.deltaTime;
        rigidBody.MovePosition(newPos);
    }

    private void HandleEnemySounds(float distanceToPlayer)
    {
        if (soundTimer > 0f)
        {
            soundTimer -= Time.deltaTime;
            return;
        }

        if (distanceToPlayer <= soundDetectionRange)
        {
            AudioManager.Instance.sfxManager.PlayEnemyIdleSound("violet");
            soundTimer = soundCooldown;
        }
    }

}
