using UnityEngine;

public class TentacleView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PowerPlayers playerPower;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject playerController;

    [SerializeField] private string attack = "isAttaking";

    void Start()
    {
        animator = GetComponent<Animator>();
        playerPower = GetComponentInParent<PowerPlayers>();
    }

    void Update()
    {
        SpriteRenderer parentRenderer = playerController.GetComponent<SpriteRenderer>();

        spriteRenderer.flipX = parentRenderer.flipX;

        animator.SetBool(attack, playerPower.isTentacleAttack);
    }
}
