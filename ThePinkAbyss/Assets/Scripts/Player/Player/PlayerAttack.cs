using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class PlayerAttack : MonoBehaviour
{
    [Header("Input Reference")]
    [SerializeField] public InputActionReference attackInput;

    [Header("Components")]
    [SerializeField] private GameObject attackHitboxRight;
    [SerializeField] private GameObject attackHitboxLeft;
    [SerializeField] private PlayerController playerController;

    [Header("Attack Settings")]
    [SerializeField] private float attackDuration = 1.0f;

    private void OnEnable()
    {
        attackInput.action.Enable();
    }
    void Start()
    {
        if (playerController == null)
            playerController = GetComponentInParent<PlayerController>();

        attackInput.action.performed += HandleAttackInput;
    }
    private void OnDisable()
    {
        attackInput.action.Disable();
    }

    void HandleAttackInput(InputAction.CallbackContext context)
    {

        if (playerController.lastViewX == 1)
        {
            StartCoroutine(AttackRight());
        }

        if (playerController.lastViewX == -1)
        {
            StartCoroutine(AttackLeft());
        }
    }

    IEnumerator AttackRight()
    {
        attackHitboxRight.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        attackHitboxRight.SetActive(false);
    }

    IEnumerator AttackLeft()
    {
        attackHitboxLeft.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        attackHitboxLeft.SetActive(false);
    }
}
