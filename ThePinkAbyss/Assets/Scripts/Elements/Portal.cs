
using UnityEngine;

public class Portal : MonoBehaviour
{
    public VictoryScreen victoryScreen;
    public HUD hud;

    private void Start()
    {
        victoryScreen = FindAnyObjectByType<VictoryScreen>();
        hud = FindAnyObjectByType<HUD>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (victoryScreen != null && hud.score > 70)
            {
                victoryScreen.ShowVictoryScreen();
            }
        }
    }


}
