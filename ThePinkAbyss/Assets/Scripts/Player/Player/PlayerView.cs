using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerPower = GetComponent<PowerPlayers>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {

        if (playerAttack != null) isAttacking = playerAttack.isAttacking;

        if(!isAttacking && player != null) {
            animator.SetBool(isJumping, player.isJumping);
            animator.SetBool(isFalling, player.isFalling);
            animator.SetBool(isNearGround, player.isNearFloor);
            animator.SetBool(isGrounded, player.isGrounded);
           
        }

        if (playerPower != null) animator.SetBool(isUsingPower, playerPower.isAttaking);

        if (playerPower != null && playerPower.hasSkin == true)
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
        if (!isAttacking) StartCoroutine(AttackAnimation());
    }

    public IEnumerator AttackAnimation()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.45f); 
    }

    public void Die()
    {
        StartCoroutine(DieAnimation());
    }

    public IEnumerator DieAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hurt");
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }


}
