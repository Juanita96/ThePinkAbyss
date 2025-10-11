using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement player;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (player.isJumping)
        {
            animator.Play("jump_1_player");
        }
        else if (player.isFalling)
        {
            animator.Play("jump_2_player");
        }
        else if (player.isNearGround)
        {
            animator.Play("jump_1_player"); 
        }
        else if (player.isGrounded)
        {
            animator.Play("idle_player");
        }
    }
}
