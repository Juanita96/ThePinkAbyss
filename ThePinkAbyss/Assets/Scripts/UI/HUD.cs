using UnityEngine;
using System.Collections;
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
    public PlayerHurt playerHurt;
    public CandiesAndOrbsCounter candiesAndOrbsCounter;
    public Pause pause;
    

    [Header("Valores iniciales")]
    [SerializeField] public float score = 0f;
    [SerializeField] private float timer = 0f;
    [SerializeField] public float cooldown = 7.5f;
    [SerializeField] public int candiesCollected;
    private int orbsInLevel;

    [SerializeField] private float cooldownTimer = 0f;
    [SerializeField] public bool cooldownActive = false;

    [SerializeField] private bool paused = false;
    [SerializeField] private bool livesDisplayActive = true;

    private bool candy1EffectActive = false;
    private bool candy2EffectActive = false;
    private bool candy3EffectActive = false;

    private  bool scoreEffectActive = false;

    private void Start()
    {

        candiesAndOrbsCounter = FindAnyObjectByType<CandiesAndOrbsCounter>();
        pause = FindAnyObjectByType<Pause>();
        playerHurt = FindAnyObjectByType<PlayerHurt>();

        if (pause != null) paused = pause.isPaused;

        lives3Display.SetActive(livesDisplayActive);
        
        orbsInLevel = GameObject.FindGameObjectsWithTag("Orb").Length;

        
    }

    private void Update()
    {
       
        if (candiesAndOrbsCounter != null) candiesCollected = candiesAndOrbsCounter.candyCollected;
        UpdateCandies();
      
        UpdateLives();

        if (!paused)
        {

            timer += Time.deltaTime;
            UpdateTimerText();


            

            if (candiesAndOrbsCounter != null && orbsInLevel>0)
            {
                score = ((float)candiesAndOrbsCounter.orbsCollected / orbsInLevel) * 100f;
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
                int tiempoRestante = Mathf.CeilToInt(cooldownTimer);
                string texto = tiempoRestante.ToString() + "s";
                powerUpCooldownText.text = texto;
            }
            else
            {
                powerUpCooldownText.text = "";
                cooldownSprite.SetActive(false);
            }

        }
    }


    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString("00") + "%";

            if(score >= 70 && !scoreEffectActive)
            {
                scoreEffectActive = true;
                StartCoroutine(ScoreEffect(scoreText.transform));
            }


        }


    }


    private void UpdateLives()
    {
    
        if (livesDisplayActive && lives3Display != null && lives2Display != null && lives1Display != null && lives0Display != null)
        {
            lives3Display.SetActive(playerHurt.lives == 3);
            lives2Display.SetActive(playerHurt.lives == 2);
            lives1Display.SetActive(playerHurt.lives == 1);
            lives0Display.SetActive(true);
        }
    }

   private void UpdateCandies()
    {
        if (candy1 != null && candy2 != null && candy3 != null)
        {
            if( candiesCollected == 0)
            {
                candy1.SetActive(false);
                candy2.SetActive(false);
                candy3.SetActive(false);
                candy1EffectActive = false;
                candy2EffectActive = false;
                candy3EffectActive = false;
            }
            if (candiesCollected >= 1 && !candy1EffectActive)
            {
                candy1.SetActive(true);
                StartCoroutine(CandyEffect(candy1.transform));
                candy1EffectActive = true;
            }
           if (candiesCollected >= 2 && !candy2EffectActive)
            {
                candy2.SetActive(true);
                StartCoroutine(CandyEffect(candy2.transform));
                candy2EffectActive = true;
            }
            if (candiesCollected >= 3 && !candy3EffectActive)
            {
                candy3.SetActive(true);
                StartCoroutine(CandyEffect(candy3.transform));
                candy3EffectActive = true;
            }
        }
    }

   private IEnumerator CandyEffect(Transform candy)
    {
        Vector3 originalScale = candy.localScale;
        Quaternion originalRotation = candy.localRotation;

        candy.localScale = originalScale * 1.3f;
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i< 6; i++)
        {
            candy.localRotation = Quaternion.Euler(0, 0, Random.Range(-15f, 15f));
            yield return new WaitForSeconds(0.03f);
        }

        candy.localRotation = originalRotation;
        candy.localScale = originalScale;

    }

    private IEnumerator ScoreEffect(Transform scoreText)
    {
        Vector3 originalScale = scoreText.transform.localScale;

        for(int i =0; i<6; i++)
        {
           scoreText.localScale = originalScale * 1.2f;
            yield return new WaitForSeconds(0.2f);
            scoreText.localScale = originalScale;
            yield return new WaitForSeconds(0.2f);
        }

        scoreText.localScale = originalScale;
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
