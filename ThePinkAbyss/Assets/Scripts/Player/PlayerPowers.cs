using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPowers : MonoBehaviour
{
    [SerializeField] private InputActionReference stealSkin;

    private PlayerAnimations playerAnimations;

    private bool canStealSkin = true;
    public bool collisionWithEnemy = false;

    private void Start()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void OnEnable()
    {
        stealSkin.action.performed += HandleStealSkinInput;
    }

    private void OnDisable()
    {
        stealSkin.action.performed -= HandleStealSkinInput;
    }

    private void HandleStealSkinInput(InputAction.CallbackContext context)
    {
        if (canStealSkin && collisionWithEnemy)
        {
            playerAnimations.PowerAnimation();
            canStealSkin = false;
        }
        else
        {
            Debug.Log("Cannot steal skin right now or no enemy nearby");
        }
    }

}
