using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

public class StealTimer : MonoBehaviour
{

    [SerializeField] private float timer = 7.0f;
    [SerializeField] private GameObject enemyPlayer;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject walls;
    public HUD hud;

    private void OnEnable()
    {
        StartCoroutine(Timer());
        hud.cooldown = timer;
        hud.StartCooldown();
    }

    private void Start()
    {
      hud = FindAnyObjectByType<HUD>();

        
    }

    IEnumerator Timer()
    {

        yield return new WaitForSeconds(timer);

        player.transform.localPosition = enemyPlayer.transform.localPosition;

        if(walls!= null)
            walls.GetComponent<TilemapCollider2D>().enabled = true;

        enemyPlayer.SetActive(false);

        player.SetActive(true);

        hud.cooldownActive = false;
    }
}
