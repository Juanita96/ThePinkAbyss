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
    [SerializeField] private GameObject bluePlayer;
    [SerializeField] private GameObject currentEnemy;
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
    [SerializeField] private bool stoleBlue = false;

    [Header("String to Variable")]
    [SerializeField] public string enemy = "Enemy";
    [SerializeField] public string violetEnemy = "VioletEnemy";
    [SerializeField] public string greenEnemy = "GreenEnemy";
    [SerializeField] public string orangeEnemy = "OrangeEnemy";
    [SerializeField] public string blueEnemy = "BlueEnemy";

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
            Destroy(currentEnemy);
            walls.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (stoleGreen == true)
        {
            greenCatPlayer.transform.localPosition = player.transform.localPosition;
            greenCatPlayer.SetActive(true);
            Destroy(currentEnemy);
        }

        if (stoleOrange == true)
        {
            orangePlayer.transform.localPosition = player.transform.localPosition;
            orangePlayer.SetActive(true);
            Destroy(currentEnemy);
        }

        if (stoleBlue == true)
        {
            bluePlayer.transform.localPosition = player.transform.localPosition;
            bluePlayer.SetActive(true);
            Destroy(currentEnemy);
        }

        isAttaking = false;
        hasSkin = false;
        canStealSkin = true;
        player.SetActive(false);
    }

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        GameObject enemyRoot = collision.transform.root.gameObject;

        if (collision.CompareTag(enemy))
        {
            collidesEnemy = true;
        }
        if (collision.CompareTag(violetEnemy))
        {
            stoleViolet = true;

            currentEnemy = enemyRoot;
        }
        if (collision.CompareTag(greenEnemy))
        {
            stoleGreen = true;

            currentEnemy = enemyRoot;
        }
        if (collision.CompareTag(orangeEnemy))
        {
            stoleOrange = true;

            currentEnemy = enemyRoot;
        }
        if (collision.CompareTag(blueEnemy))
        {
            stoleBlue = true;

            currentEnemy = enemyRoot;
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
        if (collision.CompareTag(orangeEnemy))
        {
            stoleOrange = false;
        }
        if (collision.CompareTag(blueEnemy))
        {
            stoleBlue = false;
        }
    }
}
