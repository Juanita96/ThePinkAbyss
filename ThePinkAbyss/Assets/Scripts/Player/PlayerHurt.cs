using UnityEngine;

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
            playerview.Die();
            
        }
    }

    public void TakeDamage()
    {
        lives--;
        if (lives > 0)
        {
            blood.Play();
            playerview.PlayHurt();
        }
    }

}


