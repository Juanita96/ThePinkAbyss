using UnityEngine;

public class Ramp : MonoBehaviour
{

    [Header("Components")]
    public GameObject ramp;
    public PlayerController playerController;
    public PlayerGreenController playerGreenController;
    public PlayerBlue playerBlue;
    public PlayerOrange playerOrange;
    public PlayerViolet playerViolet;

    [Header("Var")]
    [SerializeField] public bool isOnRamp = false;
    [SerializeField] public bool leftRamp;
    [SerializeField] public bool rightRamp;
    [SerializeField] private float rampSpeedModifier = 4f;
    [SerializeField] private float normalSpeed;

    private bool playerControllerActive = false;
    private bool playerGreenControllerActive = false;
    private bool playerBlueControllerActive = false;
    private bool playerOrangeControllerActive = false;
    private bool playerVioletControllerActive = false;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        playerGreenController = FindAnyObjectByType<PlayerGreenController>();
        playerBlue = FindAnyObjectByType<PlayerBlue>();
        playerOrange = FindAnyObjectByType<PlayerOrange>();
        playerViolet = FindAnyObjectByType<PlayerViolet>();

        FindActiveController();
    }

    private void Update()
    {
        FindActiveController();
    }

    private void FindActiveController()
    {
        
        if (playerController != null && playerController.gameObject.activeInHierarchy && !playerControllerActive)
        {
            playerControllerActive = true;
            playerGreenControllerActive = false;
            playerBlueControllerActive = false;
            playerOrangeControllerActive = false;
            playerVioletControllerActive = false;
        }
        else if (playerGreenController != null && playerGreenController.gameObject.activeInHierarchy && !playerGreenController)
        {
            playerGreenControllerActive = true;
            playerBlueControllerActive = false;
            playerOrangeControllerActive = false;
            playerVioletControllerActive = false;
            playerControllerActive = false;
        }
        else if (playerBlue != null && playerBlue.gameObject.activeInHierarchy && !playerBlueControllerActive)
        {
            playerBlueControllerActive = true;
            playerOrangeControllerActive = false;
            playerVioletControllerActive = false;
            playerControllerActive = false;
            playerGreenControllerActive = false;
        }
        else if (playerOrange != null && playerOrange.gameObject.activeInHierarchy && !playerOrangeControllerActive)
        {
            playerOrangeControllerActive = true;
            playerVioletControllerActive = false;
            playerControllerActive = false;
            playerGreenControllerActive = false;
            playerBlueControllerActive = false;
        }
        else if (playerViolet != null && playerViolet.gameObject.activeInHierarchy && !playerVioletControllerActive)
        {
            playerVioletControllerActive = true;
            playerOrangeControllerActive = false;
            playerVioletControllerActive = false;
            playerBlueControllerActive = false;
            playerOrangeControllerActive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftRamp"))
        {
            if (!isOnRamp)
            {
                leftRamp = true;
                isOnRamp = true;
                if (playerControllerActive)
                {
                normalSpeed = playerController.moveSpeed;
                playerController.moveSpeed *= rampSpeedModifier;
                }
                else if(playerGreenControllerActive) 
                {
                normalSpeed = playerGreenController.moveSpeed;
                playerGreenController.moveSpeed *= rampSpeedModifier;
                }
                else if (playerBlueControllerActive)
                {
                 normalSpeed = playerBlue.moveSpeed;
                 playerBlue.moveSpeed *= rampSpeedModifier;
                }
                else if (playerOrangeControllerActive)
                {
                normalSpeed = playerOrange.moveSpeed;
                playerOrange.moveSpeed *= rampSpeedModifier;
                }
                else if (playerVioletControllerActive)
                {
                normalSpeed = playerViolet.moveSpeed;
                playerViolet.moveSpeed *= rampSpeedModifier;
                }

            }
        }
        else if (collision.gameObject.CompareTag("RightRamp"))
        {
            if (!isOnRamp)
            {
                rightRamp = true;
                isOnRamp = true;

                if (playerControllerActive)
                {
                    normalSpeed = playerController.moveSpeed;
                    playerController.moveSpeed *= rampSpeedModifier;
                }
                else if (playerGreenControllerActive)
                {
                    normalSpeed = playerGreenController.moveSpeed;
                    playerGreenController.moveSpeed *= rampSpeedModifier;
                }
                else if (playerBlueControllerActive)
                {
                    normalSpeed = playerBlue.moveSpeed;
                    playerBlue.moveSpeed *= rampSpeedModifier;
                }
                else if (playerOrangeControllerActive)
                {
                    normalSpeed = playerOrange.moveSpeed;
                    playerOrange.moveSpeed *= rampSpeedModifier;
                }
                else if (playerVioletControllerActive)
                {
                    normalSpeed = playerViolet.moveSpeed;
                    playerViolet.moveSpeed *= rampSpeedModifier;
                }
                
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

                if (playerControllerActive)
                {
                    playerController.moveSpeed = normalSpeed;
                    
                }
                else if (playerGreenControllerActive)
                {
                    playerGreenController.moveSpeed = normalSpeed;
                    
                }
                else if (playerBlueControllerActive)
                {
                    playerBlue.moveSpeed = normalSpeed;
                    
                }
                else if (playerOrangeControllerActive)
                {
                    playerOrange.moveSpeed = normalSpeed;
                    
                }
                else if (playerVioletControllerActive)
                {
                    playerViolet.moveSpeed = normalSpeed;
                    
                }

            }
        }
        else if (collision.gameObject.CompareTag("RightRamp"))
        {
            if (isOnRamp)
            {
                rightRamp = false;
                isOnRamp = false;

                if (playerControllerActive)
                {
                    playerController.moveSpeed = normalSpeed;

                }
                else if (playerGreenControllerActive)
                {
                    playerGreenController.moveSpeed = normalSpeed;

                }
                else if (playerBlueControllerActive)
                {
                    playerBlue.moveSpeed = normalSpeed;

                }
                else if (playerOrangeControllerActive)
                {
                    playerOrange.moveSpeed = normalSpeed;

                }
                else if (playerVioletControllerActive)
                {
                    playerViolet.moveSpeed = normalSpeed;

                }

            }
        }
    }

}
