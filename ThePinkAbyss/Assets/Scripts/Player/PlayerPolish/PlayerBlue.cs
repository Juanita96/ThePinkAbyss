using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerBlue : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;

    [Header("Actions")]
    [SerializeField] public Vector2 moveInput;
    [SerializeField] private bool jumpInput;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Raycast")]
    private RaycastHit2D floorHit;
    [SerializeField] private float rayDistance = 1.5f;
    [SerializeField] public bool isGrounded = false;
    [SerializeField] private LayerMask groundLayer;

    [Header("Raycast Near Floor")]
    private RaycastHit2D nearFloor;
    [SerializeField] private float rayNearDist = 2f;
    [SerializeField] public bool isNearFloor;

    [Header("Components")]
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Check Bools")]
    [SerializeField] public bool isJumping;
    [SerializeField] public bool isFalling;
    [SerializeField] private bool showDebug;

    [Header("View Direction")]
    [SerializeField] public float lastViewX = 1f;

    private void OnEnable()
    {
        moveAction.action.started += HandleMoveInput;
        moveAction.action.performed += HandleMoveInput;
        moveAction.action.canceled += HandleMoveInput;

        jumpAction.action.performed += HandleJumpInput;
    }

    private void OnDisable()
    {
        moveAction.action.started -= HandleMoveInput;
        moveAction.action.performed -= HandleMoveInput;
        moveAction.action.canceled -= HandleMoveInput;

        jumpAction.action.performed -= HandleJumpInput;
    }

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void HandleMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void HandleJumpInput(InputAction.CallbackContext context)
    {
        if (isGrounded && !isJumping)
        {
            isJumping = true;
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        Movement();
        Raycast();
        RayNearFloor();
        SpriteFlip();
        Jump();
        UpdateLastView();
    }

    private void Movement()
    {
        playerRigidbody.linearVelocity = new Vector2(moveInput.x * moveSpeed, playerRigidbody.linearVelocity.y);
    }

    private void Jump()
    {
        if (!isGrounded)
        {
            isJumping = true;
        }
        if (!isGrounded && playerRigidbody.linearVelocityY < -0.1f)
        {
            isFalling = true;
        }
        if (isNearFloor)
        {
            isFalling = false;
        }
        if (isGrounded)
        {
            isJumping = false;
            isFalling = false;
            isNearFloor = false;
        }
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

    private void RayNearFloor()
    {
        nearFloor = Physics2D.Raycast(transform.position, Vector2.down, rayNearDist, groundLayer);

        if (nearFloor.collider != null)
        {
            isNearFloor = true;
            if (showDebug == true)
            {
                Debug.DrawRay(transform.position, Vector2.down * rayNearDist, Color.yellow);
            }
        }
        else
        {
            isNearFloor = false;
            if (showDebug == true)
            {
                Debug.DrawRay(transform.position, Vector2.down * rayNearDist, Color.blue);
            }
        }
    }

    public void SpriteFlip()
    {
        if (Mathf.Abs(moveInput.x) > 0.01f)
        {
            spriteRenderer.flipX = moveInput.x < 0;
        }
    }
    private void UpdateLastView()
    {
        if (Mathf.Abs(moveInput.x) > 0.01f)
        {
            lastViewX = Mathf.Sign(moveInput.x);
        }
    }
}
