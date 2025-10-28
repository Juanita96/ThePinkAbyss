using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class BlueAttack : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerBlue playerBlue;

    [Header("Particles Systems")]
    [SerializeField] private GameObject particleLeft;
    [SerializeField] private GameObject particleRight;

    [Header("Input Reference")]
    [SerializeField] private InputActionReference attackInput;


    private void Start()
    {
        attackInput.action.performed += HandleAttackInput;
    }

    private void HandleAttackInput(InputAction.CallbackContext context)
    {
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

        yield return new WaitForSeconds(1);

        particleLeft.SetActive(false);
    }

    IEnumerator RightParticle()
    {
        particleRight.SetActive(true);

        yield return new WaitForSeconds(1);

        particleRight.SetActive(false);
    }
}