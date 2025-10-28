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

    void Start()
    {
        powerInput.action.performed += HandlePowerInput;
    }

    void HandlePowerInput(InputAction.CallbackContext context)
    {
        StartCoroutine(powerUse());
    }

    IEnumerator powerUse()
    {
        powerHitbox.SetActive(true);

        yield return new WaitForSeconds(powerDuration);

        powerHitbox.SetActive(false);
    }
}
