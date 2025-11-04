using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHurt : MonoBehaviour
{
    public int lives = 1;
    private bool die = false;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerView playerview;
    public ParticleSystem blood;

    private void Start()
    {
        playerview = FindAnyObjectByType<PlayerView>();
    }

    private void Update()
    {

        if (lives <= 0 && die == false)
        {
            die = true;
            blood.Play();
            Debug.Log("Player Died");
            bool playerActive = player.activeInHierarchy;
            if (playerActive)
            {
                playerview.Die();
            }
            else
            {
                StartCoroutine(Die());

            }
        }
    }

    public void TakeDamage()
    {
        lives--;
        if (lives > 0)
        {
            blood.Play();
            bool playerActive = player.activeInHierarchy;
            if (playerActive) playerview.PlayHurt();
                
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}







