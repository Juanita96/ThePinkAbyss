using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHurt : MonoBehaviour
{
    public int lives = 1;
    private bool die = false;

    [SerializeField] private GameObject player;
    public ParticleSystem blood;

    private CameraFollow cameraFollow;

    private void Start()
    {
        cameraFollow = FindAnyObjectByType<CameraFollow>();
    }

    private void Update()
    {
        if (lives <= 0 && !die)
        {
            die = true;
            blood.Play();
            Debug.Log("Player Died");

            StartCoroutine(HandleDeath());
        }
    }

    public void TakeDamage()
    {
        lives--;
        if (lives > 0)
        {
            blood.Play();
        }
    }

    private IEnumerator HandleDeath()
    {
        
        if (cameraFollow != null)
            yield return StartCoroutine(cameraFollow.FadeOut(2f));

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
