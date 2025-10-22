using UnityEngine;
using System.Collections;

public class GreenCatBehaviour : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D catRigidbody;

    [Header("Enemy Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float movement = 1f;

    [Header("Raycast Settings")]
    public RaycastHit2D hitFloor;
    [SerializeField] public float rayDist = 2f;
    [SerializeField] public bool isGrounded = false;
    [SerializeField] public LayerMask groundLayer;

    void Start()
    {
        catRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        hitFloor = Physics2D.Raycast(transform.position, Vector2.down, rayDist, groundLayer);

        if (hitFloor.collider != null)
        {
            Debug.DrawRay(transform.position, Vector2.down * rayDist, Color.green);
            isGrounded = true;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.down * rayDist, Color.red);
            isGrounded = false;
        }

        catRigidbody.linearVelocity = new Vector2(movement, catRigidbody.linearVelocity.y);

        if (isGrounded)
        {
            catRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GreenLimit"))
        {
            movement *= -1f;
        }
    }
}
