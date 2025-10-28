using UnityEngine;
using UnityEngine.InputSystem;

public class Shrubbery : MonoBehaviour
{
    [Header("Input Reference")]
    [SerializeField] private InputActionReference hideAction;

    [Header("Check Bools")]
    [SerializeField] private bool canHide = false;
    [SerializeField] private bool isHiding = false;

    [Header("Settings")]
    [SerializeField] private float playerAlpha = 0.5f;

    [Header("Components")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer spriteRenderer;
  
    private void OnEnable()
    {
        hideAction.action.Enable();
        hideAction.action.performed += Hide;
    }

    private void OnDisable()
    {
        hideAction.action.performed -= Hide;
        hideAction.action.Disable();
    }

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerCamera = Camera.main;
        player.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shrubbery"))
        {
            canHide = true;
            Debug.Log("Jugador puede esconderse");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shrubbery"))
        {
            canHide = false;
            Debug.Log("Jugador no puede esconderse");
        }
    }

    private void Hide(InputAction.CallbackContext context)
    {
        if (canHide && !isHiding)
        {
            isHiding = true;
            playerCamera.orthographicSize = 8f;
            //Enemigos no ven al player mientras esta escondido
            Color currentCollor = spriteRenderer.material.color;
            Color newColor = new Color(currentCollor.r, currentCollor.g, currentCollor.b, playerAlpha);
            spriteRenderer.material.color = newColor;
        }
    }

    public void Update()
    {
        if (isHiding && playerController.isMoving || playerController.isJumping)
        {
            isHiding = false;
            playerCamera.orthographicSize = 5f;
            Color currentCollor = spriteRenderer.material.color;
            Color newColor = new Color(currentCollor.r, currentCollor.g, currentCollor.b, 1);
            spriteRenderer.material.color = newColor;
        }
    }

}

   
