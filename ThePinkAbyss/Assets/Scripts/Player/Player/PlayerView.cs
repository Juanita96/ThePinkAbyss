using UnityEngine;
using System.Collections;

public class PlayerView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController player;
    [SerializeField] private PowerPlayers playerPower;

    private string isGrounded = "isGrounded";
    private string isJumping = "isJumping";
    private string isNearGround = "isNearGround";
    private string isFalling = "isFalling";

    private string power = "Power";
    private string isUsingPower = "isUsingPower";

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerPower = GetComponent<PowerPlayers>();
    }

    void Update()
    {
        animator.SetBool(isJumping, player.isJumping);
        animator.SetBool(isFalling, player.isFalling);
        animator.SetBool(isNearGround, player.isNearFloor);
        animator.SetBool(isGrounded, player.isGrounded);
        animator.SetBool(isUsingPower, playerPower.isAttaking);

        if (playerPower.hasSkin == true)
        {
            animator.SetTrigger(power);
        }

    }

    public void AttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public void Hurt()
    {
        animator.SetTrigger("Hurt");
    }

    public IEnumerator Die()
    {

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
        yield return new WaitForSeconds(2f);
        Destroy(player, 2f);

    }


}
