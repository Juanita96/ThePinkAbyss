using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class OrangePower : MonoBehaviour
{
    [Header("Input Systems")]
    [SerializeField] private InputActionReference powerInput;

    [Header("Components")]
    [SerializeField] private GameObject powerHitbox;

    [Header("Power Settings")]
    [SerializeField] private float powerDuration = 1f;

    private void OnEnable()
    {
        powerInput.action.Enable();
    }

    private void Start()
    {
        powerInput.action.performed += HandlePowerInput;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        powerInput.action.Disable();
    }

    void HandlePowerInput(InputAction.CallbackContext context)
    {
        if (!isActiveAndEnabled)
        {
            return;
        }
        StartCoroutine(powerUse());
    }

    IEnumerator powerUse()
    {
        powerHitbox.SetActive(true);

        yield return new WaitForSeconds(powerDuration);

        powerHitbox.SetActive(false);
    }
}
