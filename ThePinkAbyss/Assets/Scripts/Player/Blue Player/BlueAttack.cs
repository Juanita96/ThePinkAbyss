using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class BlueAttack : MonoBehaviour
{
    [Header("Input Reference")]
    [SerializeField] public InputActionReference attackInput;

    [Header("Particles Systems")]
    [SerializeField] private GameObject particleLeft;
    [SerializeField] private GameObject particleRight;
    [SerializeField] private PlayerBlue playerBlue;

    [Header("Attack Settings")]
    [SerializeField] private float attackDuration = 1.0f;

    private void OnEnable()
    {
        attackInput.action.Enable();
    }
    void Start()
    {
        if (playerBlue == null)
            playerBlue = GetComponentInParent<PlayerBlue>();

        attackInput.action.performed += HandleAttackInput;
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        attackInput.action.Disable();
    }
    private void HandleAttackInput(InputAction.CallbackContext context)
    {
        Debug.Log("Tocate hermano");

        if (playerBlue.lastViewX == -1)
        {
            StartCoroutine(LeftParticle());
        }
        if (playerBlue.lastViewX == 1)
        {
            StartCoroutine(RightParticle());
        }
    }
    IEnumerator LeftParticle()
    {
        particleLeft.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        particleLeft.SetActive(false);
    }

    IEnumerator RightParticle()
    {
        particleRight.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        particleRight.SetActive(false);
    }
}