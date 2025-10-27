using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PowerPlayers : MonoBehaviour
{

    [Header("Input Action Reference")]
    [SerializeField] private InputActionReference stealSkinInput;

    [Header("Components")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject tentacles;
    [SerializeField] private GameObject greenCatPlayer;
    [SerializeField] private GameObject violetPlayer;
    [SerializeField] private GameObject orangePlayer;
    [SerializeField] private GameObject walls;

    [Header("Skin Steal Settings")]
    [SerializeField] public bool canStealSkin = true;
    [SerializeField] private bool collidesEnemy = false;
    [SerializeField] public bool hasSkin = false;
    [SerializeField] public bool isAttaking = false;
    [SerializeField] private float animDuration = 1.0f;
    [SerializeField] public bool isTentacleAttack = false;
    [SerializeField] public float tentacleDuration = 1.0f;

    [Header("Who Steal")]
    [SerializeField] private bool stoleViolet = false;
    [SerializeField] private bool stoleGreen = false;
    [SerializeField] private bool stoleOrange = false;

    [Header("String to Variable")]
    [SerializeField] private string enemy = "Enemy";
    [SerializeField] private string violetEnemy = "VioletEnemy";
    [SerializeField] private string greenEnemy = "GreenEnemy";
    [SerializeField] private string orangeEnemy = "OrangeEnemy";

    void Start()
    {
        stealSkinInput.action.performed += HandleStealSkin;
    }

    void HandleStealSkin(InputAction.CallbackContext context)
    {
        if (canStealSkin && collidesEnemy)
        {
            StartCoroutine(StealSkin());
        }
    }

    IEnumerator StealSkin()
    {
        hasSkin = true;
        canStealSkin = false;
        isAttaking = true;
        isTentacleAttack = true;
        tentacles.SetActive(true);

        yield return new WaitForSeconds(tentacleDuration);

        tentacles.SetActive(false);
        isTentacleAttack = false;

        yield return new WaitForSeconds(animDuration);

        if (stoleViolet == true)
        {
            violetPlayer.transform.localPosition = player.transform.localPosition;
            violetPlayer.SetActive(true);
            walls.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (stoleGreen == true)
        {
            greenCatPlayer.transform.localPosition = player.transform.localPosition;
            greenCatPlayer.SetActive(true);
        }

        if (stoleOrange == true)
        {
            orangePlayer.transform.localPosition = player.transform.localPosition;
            orangePlayer.SetActive(true);
        }

        isAttaking = false;
        hasSkin = false;
        canStealSkin = true;
        player.SetActive(false);

    }

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    { 
        if (collision.CompareTag(enemy))
        {
            collidesEnemy = true;
        }
        if (collision.CompareTag(violetEnemy))
        {
            stoleViolet = true;
        }
        if (collision.CompareTag(greenEnemy))
        {
            stoleGreen = true;
        }
        if (collision.CompareTag(orangeEnemy))
        {
            stoleOrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(enemy))
        {
            collidesEnemy = false;
        }
        if (collision.CompareTag(violetEnemy))
        {
            stoleViolet = false;
        }
        if (collision.CompareTag(greenEnemy))
        {
            stoleGreen = false;
        }
    }
}
