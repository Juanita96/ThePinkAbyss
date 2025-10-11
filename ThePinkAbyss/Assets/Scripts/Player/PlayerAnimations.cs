using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement player;
    private PlayerPowers playerPowers;

    private bool isPlayingSpecial = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
        playerPowers = GetComponent<PlayerPowers>();
    }

    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (isPlayingSpecial) return;

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

    public void PowerAnimation()
    {
       isPlayingSpecial = true;
       animator.SetTrigger("Power");
       StartCoroutine(ResetSpecial(animator.GetCurrentAnimatorStateInfo(0).length));
    }

    public void AttackAnimation()
    {
        isPlayingSpecial = true;
        animator.SetTrigger("Attack");
        StartCoroutine(ResetSpecial(animator.GetCurrentAnimatorStateInfo(0).length));
    }

    public void DyingAnimation()
    {
        isPlayingSpecial = true;
        animator.SetTrigger("Die");
        StartCoroutine(ResetSpecial(animator.GetCurrentAnimatorStateInfo(0).length));
    }

    public void HurtAnimation() {
        isPlayingSpecial = true;
        animator.SetTrigger("Hurt");
        StartCoroutine(ResetSpecial(animator.GetCurrentAnimatorStateInfo(0).length));
    }

    private IEnumerator ResetSpecial(float delay)
    {
        yield return new WaitForSeconds(delay);
        isPlayingSpecial = false;
    }

}
