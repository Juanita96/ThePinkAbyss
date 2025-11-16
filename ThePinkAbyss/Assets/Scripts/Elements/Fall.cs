using UnityEngine;

public class Fall : MonoBehaviour
{
    public float slowGravityScale = 0.2f; 
    public float normalGravityScale = 3f;   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rigidBody = other.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
                rigidBody.gravityScale = slowGravityScale;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rigidBody = other.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
                rigidBody.gravityScale = normalGravityScale;
        }
    }
}
