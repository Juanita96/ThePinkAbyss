using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public int lives = 1;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerView playerview;

    private void Start()
    {
        playerview = GetComponent<PlayerView>();
    }

    private void Update()
    {
        if (lives <= 0)
        {
            playerview.Die();
        }
    }

}


