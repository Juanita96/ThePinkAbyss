using UnityEngine;

public class PowerCollider : MonoBehaviour
{
    [SerializeField] private PlayerPowers playerPowers; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerPowers.collisionWithEnemy = true;
            Debug.Log("Jugador en rango del enemigo");
        }
    }
}
