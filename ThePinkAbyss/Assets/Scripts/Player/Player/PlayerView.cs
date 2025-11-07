using UnityEngine;
using System.Collections;

public class PlayerView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController player;
    [SerializeField] private PowerPlayers playerPower;
    [SerializeField] private PlayerAttack playerAttack;

    private string isGrounded = "isGrounded";
    private string isJumping = "isJumping";
    private string isNearGround = "isNearGround";
    private string isFalling = "isFalling";

    private string power = "Power";
    private string isUsingPower = "isUsingPower";
    private bool isAttacking = false;

   private  void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerPower = GetComponent<PowerPlayers>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if (playerAttack != null)
            isAttacking = playerAttack.isAttacking;

        if (!isAttacking && player != null)
        {
            animator.SetBool(isJumping, player.isJumping);
            animator.SetBool(isFalling, player.isFalling);
            animator.SetBool(isNearGround, player.isNearFloor);
            animator.SetBool(isGrounded, player.isGrounded);
        }

        if (playerPower != null)
            animator.SetBool(isUsingPower, playerPower.isAttaking);

        if (playerPower != null && playerPower.hasSkin)
        {
            animator.SetTrigger(power);
        }
    }

    public void PlayHurt()
    {
        StartCoroutine(HurtAnimation());
    }

    public IEnumerator HurtAnimation()
    {
        animator.SetTrigger("Hurt");
        yield return new WaitForSeconds(0.2f);
    }

    public void PlayAttack()
    {
        if (!isAttacking)
            StartCoroutine(AttackAnimation());
    }

    public IEnumerator AttackAnimation()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.45f);
    }

}
