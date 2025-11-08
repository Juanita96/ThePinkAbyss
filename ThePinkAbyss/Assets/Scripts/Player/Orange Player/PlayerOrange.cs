using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOrange : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;

    [Header("Actions")]
    [SerializeField] public Vector2 moveInput;
    [SerializeField] private bool jumpInput;

    [Header("Settings")]
    [SerializeField] public float moveSpeed = 5f;
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
    public Ramp ramp;

    [Header("Check Bools")]
    [SerializeField] public bool isJumping;
    [SerializeField] public bool isFalling;
    [SerializeField] private bool showDebug;
    private bool hasPlayedLandSound = false;
    private bool hasPlayedJumpSound = false;

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
        ramp = FindAnyObjectByType<Ramp>();
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
            hasPlayedLandSound = false;
            if (!hasPlayedJumpSound)
            {
                AudioManager.Instance.sfxManager.PlayJump();
                hasPlayedJumpSound = true;
                
            }
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
    }

    private void Movement()
    {
        if (!ramp.isOnRamp)
        {
            playerRigidbody.linearVelocity = new Vector2(moveInput.x * moveSpeed, playerRigidbody.linearVelocity.y);
        }
        else if (ramp.isOnRamp)
        {
            if (ramp.rightRamp) playerRigidbody.linearVelocity = new Vector2(1 * moveSpeed, playerRigidbody.linearVelocity.y);
            if (ramp.leftRamp) playerRigidbody.linearVelocity = new Vector2(-1 * moveSpeed, playerRigidbody.linearVelocity.y);
        }
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
            if (!hasPlayedLandSound && isFalling)
            {
                AudioManager.Instance.sfxManager.PlayLand();
                hasPlayedLandSound = true;
                hasPlayedJumpSound = false;
            }
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
}
