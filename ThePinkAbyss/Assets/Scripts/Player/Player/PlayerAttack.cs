using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    [Header("Input Reference")]
    [SerializeField] public InputActionReference attackInput;

    [Header("Components")]
    [SerializeField] private GameObject attackHitboxRight;
    [SerializeField] private GameObject attackHitboxLeft;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerView playerView;

    [Header("Attack Settings")]
    [SerializeField] private float attackDuration = 0.45f; 

    public bool isAttacking = false;

    private void OnEnable()
    {
        attackInput.action.Enable();
    }

    private void Start()
    {
        if (playerController == null)
            playerController = GetComponentInParent<PlayerController>();
        if (playerView == null)
            playerView = GetComponentInParent<PlayerView>();

        attackInput.action.performed += HandleAttackInput;
    }

    private void OnDisable()
    {
        attackInput.action.Disable();
    }

    private void HandleAttackInput(InputAction.CallbackContext context)
    {
        if (!isAttacking)
        {
            StartCoroutine(AttackSequence());
        }
    }

    private IEnumerator AttackSequence()
    {
        isAttacking = true;

        yield return StartCoroutine(playerView.AttackAnimation());

        if (playerController.lastViewX == 1)
        {
            attackHitboxRight.SetActive(true);
        }
        else if (playerController.lastViewX == -1)
        {
            attackHitboxLeft.SetActive(true);
        }

        yield return new WaitForSeconds(attackDuration);

        attackHitboxRight.SetActive(false);
        attackHitboxLeft.SetActive(false);

        isAttacking = false;
    }

   
}
