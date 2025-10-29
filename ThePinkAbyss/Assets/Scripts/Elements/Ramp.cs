using UnityEngine;

public class Ramp : MonoBehaviour
{

    [Header("Components")]
    public GameObject ramp;
    [SerializeField] private PlayerController playerController;

    [Header("Var")]
    [SerializeField] public bool isOnRamp = false;
    [SerializeField] public bool leftRamp;
    [SerializeField] public bool rightRamp;
    [SerializeField] private float rampSpeedModifier = 4f;
    [SerializeField] private float normalSpeed;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftRamp"))
        {
            if (!isOnRamp)
            {
                leftRamp = true;
                isOnRamp = true;
                normalSpeed = playerController.moveSpeed;
                playerController.moveSpeed *= rampSpeedModifier;
                Debug.Log("Entered Ramp: Speed increased to " + playerController.moveSpeed);
            }
        }
        else if (collision.gameObject.CompareTag("RightRamp"))
        {
            if (!isOnRamp)
            {
                rightRamp = true;
                isOnRamp = true;
                normalSpeed = playerController.moveSpeed;
                playerController.moveSpeed *= rampSpeedModifier;
                Debug.Log("Entered Ramp: Speed increased to " + playerController.moveSpeed);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftRamp"))
        {
            if (isOnRamp)
            {
                leftRamp = false;
                isOnRamp = false;
                playerController.moveSpeed = normalSpeed;
                Debug.Log("Exited Ramp: Speed reverted to " + playerController.moveSpeed);
            }
        }
        else if (collision.gameObject.CompareTag("RightRamp"))
        {
            if (isOnRamp)
            {
                rightRamp = false;
                isOnRamp = false;
                playerController.moveSpeed = normalSpeed;
                Debug.Log("Exited Ramp: Speed reverted to " + playerController.moveSpeed);
            }
        }
    }

}
