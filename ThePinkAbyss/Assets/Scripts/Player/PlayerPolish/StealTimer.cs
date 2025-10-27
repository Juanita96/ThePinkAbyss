using UnityEngine;
using System.Collections;

public class StealTimer : MonoBehaviour
{

    [SerializeField] private float timer = 7.0f;
    [SerializeField] private GameObject enemyPlayer;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject walls;

    private void OnEnable()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);

        player.transform.localPosition = enemyPlayer.transform.localPosition;

        walls.GetComponent<BoxCollider2D>().enabled = true;

        enemyPlayer.SetActive(false);
        player.SetActive(true);
    }
}
