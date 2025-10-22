using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController player;

    private string isGrounded = "isGrounded";
    private string isJumping = "isJumping";
    private string isNearGround = "isNearGround";
    private string isFalling = "isFalling";

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        animator.SetBool(isJumping, player.isJumping);
        animator.SetBool(isFalling, player.isFalling);
        animator.SetBool(isNearGround, player.isNearFloor);
        animator.SetBool(isGrounded, player.isGrounded);
    }
}
