using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        animator.SetBool("isRunning", movement.isMoving);
        animator.SetBool("isJumpping", movement.jumpOnGround);
        animator.SetBool("isGrounded", movement.isGrounded);
    }
}