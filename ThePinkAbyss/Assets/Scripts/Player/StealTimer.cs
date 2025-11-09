using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

public class StealTimer : MonoBehaviour
{
    [SerializeField] private PowerPlayers powerPlayers;
    [SerializeField] private float timer = 7.0f;
    [SerializeField] private GameObject enemyPlayer;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject walls;
    [SerializeField] private PlayerController playerController;
    public CameraFollow cameraFollow;
    public HUD hud;

    private void Awake()
    {
        hud = FindAnyObjectByType<HUD>();
        cameraFollow = FindAnyObjectByType<CameraFollow>();
    }

    private void OnEnable()
    {
        StartCoroutine(Timer());
        cameraFollow.StartCoroutine(cameraFollow.JakeCamera());

        hud.cooldown = timer;
        hud.StartCooldown();
    }

    IEnumerator Timer()
    {

        yield return new WaitForSeconds(timer);

        player.transform.localPosition = enemyPlayer.transform.localPosition;

        if(walls!= null)
            walls.GetComponent<TilemapCollider2D>().enabled = true;

        enemyPlayer.SetActive(false);

        cameraFollow.StartCoroutine(cameraFollow.JakeCamera());

        playerController.moveInput = Vector2.zero;

        player.SetActive(true);

        hud.cooldownActive = false;

        powerPlayers.isOrangeVisible = false;
    }
}
