using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Tilemaps;

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
    public CameraFollow cameraFollow;

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
        cameraFollow = FindAnyObjectByType<CameraFollow>();
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
            currentEnemy.SetActive(false);
            walls.GetComponent<TilemapCollider2D>().enabled = false;
            player.SetActive(false);
        }

        else if (stoleGreen == true)
        {
            greenCatPlayer.transform.localPosition = player.transform.localPosition;
            greenCatPlayer.SetActive(true);
            currentEnemy.SetActive(false);
            player.SetActive(false);
        }

        else if (stoleOrange == true)
        {
            orangePlayer.transform.localPosition = player.transform.localPosition;
            orangePlayer.SetActive(true);
            currentEnemy.SetActive(false);
            player.SetActive(false);
        }

        else if (stoleBlue == true)
        {
            bluePlayer.transform.localPosition = player.transform.localPosition;
            bluePlayer.SetActive(true);
            currentEnemy.SetActive(false);
            player.SetActive(false);
        }
        isAttaking = false;
        hasSkin = false;
        canStealSkin = true;
    }

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        GameObject enemyRoot = collision.transform.root.gameObject;

        if (collision.CompareTag(enemy))
        {
            collidesEnemy = true;
        }
        else if (collision.CompareTag(violetEnemy) && !stoleViolet && !stoleGreen && !stoleOrange && !stoleBlue)
        {
            ResetStealFlags();
            stoleViolet = true;
            currentEnemy = enemyRoot;
        }
        else if (collision.CompareTag(greenEnemy) && !stoleViolet && !stoleGreen && !stoleOrange && !stoleBlue)
        {
            ResetStealFlags();
            stoleGreen = true;
            currentEnemy = enemyRoot;
        }
        else if (collision.CompareTag(orangeEnemy) && !stoleViolet && !stoleGreen && !stoleOrange && !stoleBlue)
        {
            ResetStealFlags();
            stoleOrange = true;
            currentEnemy = enemyRoot;
        }
        else if (collision.CompareTag(blueEnemy) && !stoleViolet && !stoleGreen && !stoleOrange && !stoleBlue)
        {
            ResetStealFlags();
            stoleBlue = true;
            currentEnemy = enemyRoot;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject enemyRoot = collision.transform.root.gameObject;

        if (collision.CompareTag(enemy))
        {
            collidesEnemy = false;
            cameraFollow.SetTarget(player.transform);
            currentEnemy = enemyRoot;
        }
        if (collision.CompareTag(violetEnemy))
        {
            stoleViolet = false;
            cameraFollow.SetTarget(player.transform);
            currentEnemy = enemyRoot;
        }
        if (collision.CompareTag(greenEnemy))
        {
            stoleGreen = false;
            cameraFollow.SetTarget(player.transform);
            currentEnemy = enemyRoot;
        }
        if (collision.CompareTag(orangeEnemy))
        {
            stoleOrange = false;
            cameraFollow.SetTarget(player.transform);
            currentEnemy = enemyRoot;
        }
        if (collision.CompareTag(blueEnemy))
        {
            stoleBlue = false;
            cameraFollow.SetTarget(player.transform);
            currentEnemy = enemyRoot;
        }
    }
    void ResetStealFlags()
    {
        stoleViolet = false;
        stoleGreen = false;
        stoleOrange = false;
        stoleBlue = false;
    }
}
