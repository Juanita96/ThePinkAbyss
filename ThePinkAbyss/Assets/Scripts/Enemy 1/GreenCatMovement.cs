using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GreenCatMovement : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float moveDistance = 3.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float jumpInterval = 2.0f;
    [SerializeField] public bool isJumping = false;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float soundCooldown = 3f;
    private float soundTimer;
    private Transform player;


    [Header("Raycast")]
    private RaycastHit2D floorHit;
    [SerializeField] private float rayDistance = 1.5f;
    [SerializeField] public bool isGrounded = false;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool showDebug = false;

    private Rigidbody2D rigidBody;
    private Vector2 startPos;
    private bool movingRight = true;
    private float jumpTimer;
    [SerializeField] private Animator animator;
    private string jump = "Jump";

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        jumpTimer = jumpInterval;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        soundTimer = soundCooldown;

    }

    void Update()
    {
        float distanceFromStart = transform.position.x - startPos.x;
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool(jump, isJumping);

        if (!isGrounded)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }


        if (isGrounded)
        {
            if (movingRight && distanceFromStart >= moveDistance)
            {
                movingRight = false;
            }
            else if (!movingRight && distanceFromStart <= -moveDistance)
            {
                movingRight = true;
            }
            if (movingRight == true)
            {
                rigidBody.linearVelocity = new Vector2(1 * moveSpeed, rigidBody.linearVelocity.y);
            }
            else if (movingRight == false)
            {
                rigidBody.linearVelocity = new Vector2(-1 * moveSpeed, rigidBody.linearVelocity.y);
            }
        }
        else
        {
            rigidBody.linearVelocity = new Vector2(0, rigidBody.linearVelocity.y);
        }

        Raycast();

        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0f)
        {
            if (isGrounded)
            {
                Jump();
            }

            jumpTimer = jumpInterval;
        }

        soundTimer -= Time.deltaTime;
        if (player != null && soundTimer <= 0f)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= detectionRange)
            {
                AudioManager.Instance.sfxManager.PlayEnemyIdleSound("green");
                soundTimer = soundCooldown;
            }
        }


    }

    void Jump()
    {
        isJumping = true;

        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= detectionRange)
            {
                AudioManager.Instance.sfxManager.PlayEnemyPower("green");
            }
        }

        rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }


    private void Raycast()
    {
        floorHit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);

        if (floorHit.collider != null)
        {
            isGrounded = true;
            if (showDebug == true)
            {
                Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.green);
            }
        }
        else
        {
            isGrounded = false;
            if (showDebug == true)
            {
                Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
            }
        }
    }



}