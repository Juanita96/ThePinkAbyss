using UnityEngine;

public class SFX : MonoBehaviour
{

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;

    private AudioManager audioManager;

    [Header("Sonidos simples")]
    public AudioClip uiClick;
    public AudioClip playerAttack;
    public AudioClip playerPower;
    public AudioClip playerHurt;
    public AudioClip enemyHurt;
    public AudioClip candyPickup;
    public AudioClip orbPickup;
    public AudioClip portal;
    public AudioClip ramp;
    public AudioClip torch;
    public AudioClip death;
    public AudioClip darkness;
    public AudioClip uiHover;
    public AudioClip uiPlay;
    public AudioClip land;
    public AudioClip jump;
    public AudioClip deathTransition;
    public AudioClip splash;

    [Header("Sonidos con variaciones")]
    public AudioClip[] enemyGreen;
    public AudioClip[] enemyOrange;
    public AudioClip[] enemyViolet;
    public AudioClip[] enemyBlue;
    public AudioClip[] powerGreen;
    public AudioClip[] powerOrange;
    public AudioClip[] powerViolet;
    public AudioClip[] powerBlue;

    [Header("Intensidades base (referencia de volumen por tipo de sonido)")]
    [Header("UI")]
    [Range(0f, 1f)] public float uiHoverIntensity = 0.25f;
    [Range(0f, 1f)] public float uiPlayIntensity = 0.35f;
    [Range(0f, 1f)] public float deathTransitionIntensity = 0.5f; //ok
    [Range(0f, 1f)] public float uiClickIntensity = 0.40f;
    [Range(0f, 1f)] public float splashIntensity = 0.30f; 

    [Header("Jugador")]
    [Range(0f, 1f)] public float jumpIntensity = 0.4f;//ok
    [Range(0f, 1f)] public float landIntensity = 0.35f; //ok
    [Range(0f, 1f)] public float playerAttackIntensity = 0.35f; //ok
    [Range(0f, 1f)] public float playerHurtIntensity = 0.20f; //ok
    [Range(0f, 1f)] public float deathIntensity = 0.50f; //ok
    [Range(0f, 1f)] public float playerPowerIntensity = 0.35f; //ok

    [Header("Elements")]
    [Range(0f, 1f)] public float candyPickupIntensity = 0.30f; //ok
    [Range(0f, 1f)] public float orbPickupIntensity = 0.30f; //ok
    [Range(0f, 1f)] public float portalIntensity = 0.50f; //ok
    [Range(0f, 1f)] public float rampIntensity = 0.20f; //ok
    [Range(0f, 1f)] public float torchIntensity = 0.20f; //ok
    [Range(0f, 1f)] public float darknessIntensity = 0.35f; //ok

    [Header("Enemies")] //ok
    [Range(0f, 1f)] public float enemyHurtIntensity = 0.25f; 
    [Range(0f, 1f)] public float enemyGreenIntensity = 0.30f; 
    [Range(0f, 1f)] public float enemyOrangeIntensity = 0.30f;
    [Range(0f, 1f)] public float enemyVioletIntensity = 0.30f;
    [Range(0f, 1f)] public float enemyBlueIntensity = 0.30f;
    [Range(0f, 1f)] public float powerGreenIntensity = 0.35f;
    [Range(0f, 1f)] public float powerOrangeIntensity = 0.35f;
    [Range(0f, 1f)] public float powerVioletIntensity = 0.35f;
    [Range(0f, 1f)] public float powerBlueIntensity = 0.35f;
   

    private void Awake()
    {
        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
        }
        audioManager = AudioManager.Instance;
    }

    public void PlaySFX(AudioClip clip, float baseIntensity, float pitchVariation = 0f)
    {
        if (clip == null || sfxSource == null) return;

        float globalSFX = 1f;
        if (audioManager != null)
        {
            globalSFX = audioManager.GetSFXVolume();
        }
        float finalVolume = Mathf.Clamp01(baseIntensity * globalSFX);
        sfxSource.pitch = 1f + Random.Range(-pitchVariation, pitchVariation);
        sfxSource.PlayOneShot(clip, finalVolume);

    }

    private void PlayRandomFromArray(AudioClip[] clips, float baseIntensity, float pitchVariation = 0f)
    {
        if (clips == null || clips.Length == 0) return;
        int randomIndex = Random.Range(0, clips.Length);
        PlaySFX(clips[randomIndex], baseIntensity, pitchVariation);
    }

    public void PlayUIClick()
    {
        PlaySFX(uiClick, uiClickIntensity, 0.05f);
    }

    public void PlayPlayerAttack()
    {
        PlaySFX(playerAttack, playerAttackIntensity, 0.1f);
    }

    public void PlayPlayerHurt()
    {
        PlaySFX(playerHurt, playerHurtIntensity, 0.1f);
    }

    public void PlayEnemyHurt()
    {
        PlaySFX(enemyHurt, enemyHurtIntensity, 0.1f);
    }

    public void PlayCandyPickup()
    {
        PlaySFX(candyPickup, candyPickupIntensity, 0.05f);
    }

    public void PlayOrbPickup()
    {
        PlaySFX(orbPickup, orbPickupIntensity, 0.05f);
    }

    public void PlayPortal()
    {
        PlaySFX(portal, portalIntensity, 0.1f);
    }

    public void PlayRamp()
    {
        PlaySFX(ramp, rampIntensity, 0.1f);
    }

    public void PlayTorch()
    {
        PlaySFX(torch, torchIntensity, 0.1f);
    }

    public void PlayDeath()
    {
        PlaySFX(death, deathIntensity, 0.1f);
    }

    public void PlayDarkness()
    {
        PlaySFX(darkness, darknessIntensity, 0.1f);
    }

    public void PlayUIHover()
    {
        PlaySFX(uiHover, uiHoverIntensity, 0.02f);
    }

    public void PlayUIPlay()
    {
        PlaySFX(uiPlay, uiPlayIntensity, 0.03f);
    }

    public void PlayJump()
    {
        PlaySFX(jump, jumpIntensity, 0.05f);
    }

    public void PlayLand()
    {
        PlaySFX(land, landIntensity, 0.03f);
    }

    public void PlayDeathTransition()
    {
        PlaySFX(deathTransition, deathTransitionIntensity, 0.04f);
    }

    public void PlaySplash()
    {
        PlaySFX(splash, splashIntensity, 0.05f);
    }

    public void PlayPlayerPower()
    {
        PlaySFX(playerPower, playerPowerIntensity, 0.1f);
    }


    public void PlayEnemyIdleSound(string color)
    {
        switch (color.ToLower())
        {
            case "green":
                PlayRandomFromArray(enemyGreen, enemyGreenIntensity, 0.1f);
                break;
            case "orange":
                PlayRandomFromArray(enemyOrange, enemyOrangeIntensity, 0.1f);
                break;
            case "violet":
                PlayRandomFromArray(enemyViolet, enemyVioletIntensity, 0.1f);
                break;
            case "blue":
                PlayRandomFromArray(enemyBlue, enemyBlueIntensity, 0.1f);
                break;
            default:
                Debug.Log("Color de enemigo no reconocido: " + color);
                break;
        }
    }

    public void PlayEnemyPower(string color)
    {
        switch (color.ToLower())
        {
            case "green":
                PlayRandomFromArray(powerGreen, powerGreenIntensity, 0.1f);
                break;
            case "orange":
                PlayRandomFromArray(powerOrange, powerOrangeIntensity, 0.1f);
                break;
            case "violet":
                PlayRandomFromArray(powerViolet, powerVioletIntensity, 0.1f);
                break;
            case "blue":
                PlayRandomFromArray(powerBlue, powerBlueIntensity, 0.1f);
                break;
            default:
                Debug.Log("Color de power-up no reconocido: " + color);
                break;
        }
    }



}