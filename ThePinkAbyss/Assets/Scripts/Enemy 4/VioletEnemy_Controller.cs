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
    [SerializeField] private Transform player;
    [SerializeField] private bool isChasing = false;

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerHurt playerHurt;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        isChasing = distanceToPlayer <= detectionRadius;

        if (isChasing)
        {
            ChasePlayer();
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
        Vector2 dir = (player.position - transform.position).normalized;
        Vector2 newPos = rigidBody.position + dir * chaseSpeed * Time.deltaTime;
        rigidBody.MovePosition(newPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
