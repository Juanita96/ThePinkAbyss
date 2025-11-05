using Unity.VisualScripting;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    [SerializeField] private PlayerHurt playerLifes;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerLifes.lives = 0;
        }
    }

}
