using UnityEngine;
using UnityEngine.Tilemaps;

public class Doors : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private string torchLightTag = "TorchLight"; 
    [SerializeField] private float transparentAlpha = 0.4f;       

    private Tilemap tilemap;
    private TilemapCollider2D tilemapCollider;
    private Color originalColor;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapCollider = GetComponent<TilemapCollider2D>();

        if (tilemap != null)
            originalColor = tilemap.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(torchLightTag))
        {
          
            if (tilemapCollider != null)
                tilemapCollider.enabled = false;

            
            if (tilemap != null)
            {
                Color c = originalColor;
                c.a = transparentAlpha;
                tilemap.color = c;
            }
        }
    }


}
