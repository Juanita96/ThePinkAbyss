using UnityEngine;

public class TentacleView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PowerPlayers playerPower;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private string attack = "isAttaking";

    void Start()
    {
        animator = GetComponent<Animator>();
        playerPower = GetComponentInParent<PowerPlayers>();
        playerController = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        if (Mathf.Abs(playerController.moveInput.x) > 0.01f)
        {
            spriteRenderer.flipX = playerController.moveInput.x < 0;
        }

        animator.SetBool(attack, playerPower.isTentacleAttack);
    }
}
