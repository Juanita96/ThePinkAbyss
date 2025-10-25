using UnityEngine;

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
    private string isAttaking = "isAttaking";

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
        animator.SetBool(isAttaking, playerPower.isAttaking);

        if (playerPower.hasSkin == true)
        {
            animator.SetTrigger(power);
        }
    }
}
