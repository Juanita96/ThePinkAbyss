using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class Doors : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private GameObject requiredLampLight; 
    [SerializeField] private float transparentAlpha = 0.4f;

    private Tilemap tilemap;
    private TilemapCollider2D tilemapCollider;
    private Color originalColor;
    private bool isOpen = false;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapCollider = GetComponent<TilemapCollider2D>();

        if (tilemap != null)
            originalColor = tilemap.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject == requiredLampLight)
        {
            var light2D = other.GetComponent<Light2D>();

            if (light2D != null && light2D.enabled && !isOpen)
            {
                AbrirPuerta();
            }
        }
    }

    private void AbrirPuerta()
    {
        isOpen = true;

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
