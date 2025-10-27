using UnityEngine;
using UnityEngine.InputSystem;

public class Shrubbery : MonoBehaviour
{
    [SerializeField] private InputActionReference hideAction;
    private bool canHide = false;
    private bool isHiding = false;

    public Shrubbery shrubbery;
    private Camera camera;
    private PlayerController playerController;
  
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
        camera = Camera.main;
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
            camera.orthographicSize = 8f;
            //Enemigos no ven al player mientras esta escondido
            //Se vuelve transparente el player
        }
    }

    public void isMoving()
    {
        if (isHiding)
        {
        isHiding = false;
        camera.orthographicSize = 5f;
        }
    }

}

   
