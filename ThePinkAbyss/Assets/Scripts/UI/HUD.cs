using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_Text powerUpCooldownText;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public GameObject lives3Display; 
    public GameObject lives2Display;
    public GameObject lives1Display;
    public GameObject lives0Display;
    public GameObject candy1;
    public GameObject candy2;
    public GameObject candy3;
    public GameObject cooldownSprite;
    public GameObject victoryScreen;
    public PlayerController player;
    public Orbs orbs;
    public Candies candies;
    public Pause pause;
    

    [Header("Valores iniciales")]
    [SerializeField] private float score = 0f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float cooldown = 7.5f;
    [SerializeField] private int lives;
    [SerializeField] private int candiesCollected;
    private int orbsInLevel;

    [SerializeField] private float cooldownTimer = 0f;
    [SerializeField] private bool cooldownActive = false;

    [SerializeField] private bool paused = false;
    [SerializeField] private bool victoryScreenActive = false;
    [SerializeField] private bool livesDisplayActive = true;

    private void Start()
    {

         orbs = FindObjectOfType<Orbs>();
         player = FindObjectOfType<PlayerController>();
         candies = FindObjectOfType<Candies>();
         pause = FindObjectOfType<Pause>();

        if (player != null) lives = player.lives;
        if (pause != null) paused = pause.isPaused;

        lives3Display.SetActive(livesDisplayActive);
        
        orbsInLevel = GameObject.FindGameObjectsWithTag("Orb").Length;

        
    }

    private void Update()
    {
       
        if (candies != null) candiesCollected = candies.candyCollected;
        UpdateCandies();
      
        UpdateLives();

        if (!paused)
        {

            timer += Time.deltaTime;
            UpdateTimerText();


            

            if (orbs != null && orbsInLevel>0)
            {
                score = ((float)orbs.orbsCollected / orbsInLevel) * 100f;
                UpdateScoreText();
            }else if(orbsInLevel == 0)
            {
                score = 100f;
                UpdateScoreText();
            }


            if (cooldownActive)
            {
                cooldownTimer -= Time.deltaTime;
                UpdateCooldownText();

                if (cooldownTimer <= 0)
                {
                    cooldownActive = false;
                    cooldownTimer = 0;
                    powerUpCooldownText.color = Color.white;
                    powerUpCooldownText.transform.localScale = Vector3.one;
                    UpdateCooldownText();
                }
                else if (cooldownTimer < 3)
                {
                    powerUpCooldownText.color = Color.red;
                    powerUpCooldownText.transform.localScale = Vector3.one * 1.2f;
                }
                else
                {
                    powerUpCooldownText.color = Color.white;
                    powerUpCooldownText.transform.localScale = Vector3.one;
                }
            }
        }
        else
        {
            cooldownSprite.SetActive(false);
        }
    }


    public void StartCooldown()
    {
        cooldownActive = true;
        cooldownSprite.SetActive(true);
        cooldownTimer = cooldown;
        UpdateCooldownText();
    }


    private void UpdateCooldownText()
    {
        if (powerUpCooldownText != null)
        {
            if (cooldownActive)
            {
                float tiempoRestante = cooldownTimer;
                string texto = "CD: " + tiempoRestante.ToString("F1") + "s";
                powerUpCooldownText.text = texto;
            }
            else
            {
                powerUpCooldownText.text = "";
            }

        }
    }


    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score + "%";
        }

    }


    private void UpdateLives()
    {
    
        if (livesDisplayActive && lives3Display != null && lives2Display != null && lives1Display != null && lives0Display != null)
        {
            lives3Display.SetActive(lives == 3);
            lives2Display.SetActive(lives == 2);
            lives1Display.SetActive(lives == 1);
            lives0Display.SetActive(true);
        }
    }

   private  void UpdateCandies()
    {
        if (candy1 != null && candy2 != null && candy3 != null)
        {
            candy1.SetActive(candiesCollected >= 1);
            candy2.SetActive(candiesCollected >= 2);
            candy3.SetActive(candiesCollected == 3);
        }
    }


   private  void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);

            string textoTimer = minutes.ToString("00") + ":" + seconds.ToString("00");
            timerText.text = textoTimer;
        }
    }


}
