using UnityEngine;

public class TentacleView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PowerPlayers playerPower;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private float lastViewTen = 1;

    [SerializeField] private string attack = "isAttaking";

    void Start()
    {
        animator = GetComponent<Animator>();
        playerPower = GetComponentInParent<PowerPlayers>();
    }

    void Update()
    {
        lastViewTen = playerController.lastViewX;

        if (lastViewTen <= -1)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX= false;
        }

        animator.SetBool(attack, playerPower.isTentacleAttack);
    }
}
