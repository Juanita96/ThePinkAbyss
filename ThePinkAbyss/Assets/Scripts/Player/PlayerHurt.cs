using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public int lives = 1;

    [SerializeField] private GameObject player;

    private void Update()
    {
        if (lives <= 0)
        {
            Destroy(enemy);
        }
    }
}
