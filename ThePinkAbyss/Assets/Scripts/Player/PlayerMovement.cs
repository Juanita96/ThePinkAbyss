using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static bool gameStarted = true;

    [SerializeField] private InputActionReference moveAction;
    public Vector2 moveInput;
    public Vector2 lastMoveDirection = Vector2.right;

    [SerializeField] private InputActionReference jumpAction;
    private bool jumpInput;


    [SerializeField] private LayerMask groundLayer;

    //raycast
    public RaycastHit2D hitFloor; 
    public float rayDist = 2f;
    public bool isGrounded = false;

    //movement
    public float moveSpeed = 7f;
    public float jumpForce = 7f;

    //bools state
    public bool isMoving => Mathf.Abs(moveInput.x) > 0.01f; 
    public bool jumpOnGround = false;
    public bool isJumping = false;
    public bool isFalling = false;
    public bool isNearGround = false;

    private bool jumpPressed;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        moveAction.action.started += HandleMoveInput;
        moveAction.action.performed += HandleMoveInput;
        moveAction.action.canceled += HandleMoveInput;

        jumpAction.action.performed += HandleJumpInput;
    }

    void HandleMoveInput(InputAction.CallbackContext context)
    {
        Debug.Log("Move Input Detected");
        moveInput = context.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput;
        }
    }

    void HandleJumpInput(InputAction.CallbackContext context)
    {
        jumpPressed = true;

        if (isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpOnGround = true;
        }

    }

    void Update()
    {
        if (!gameStarted) return;

        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        hitFloor = Physics2D.Raycast(transform.position, Vector2.down, rayDist, groundLayer);

        if (hitFloor.collider != null)
        {
            Debug.DrawRay(transform.position, Vector2.down * rayDist, Color.green);
            isGrounded = true;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.down * rayDist, Color.red);
            isGrounded = false;
            jumpOnGround = false;
        }

        //types of jumping
        if (!isGrounded && rb.linearVelocity.y > 0.1f)
        {
            isJumping = true;
            isFalling = false;
        }
        else if (!isGrounded && rb.linearVelocity.y < -0.1f)
        {
            isJumping = false;
            isFalling = true;
        }
        else if (isGrounded)
        {
            isJumping = false;
            isFalling = false;
        }

        isNearGround = !isGrounded && hitFloor.collider != null && hitFloor.distance < (rayDist * 0.5f);

        // Flip sprite
        if (moveInput.x > 0.01f)
        {
            sr.flipX = false;
        }
        else if (moveInput.x < -0.01f)
        {
            sr.flipX = true;
        }
    }
}