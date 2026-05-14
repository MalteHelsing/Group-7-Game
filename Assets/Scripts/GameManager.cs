using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static DifficultyManager;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] private GameObject key;
    [SerializeField] public GameObject gamblingMachine;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] public GameObject powerup;
    [SerializeField] public Sprite[] changeDoor;  
    [SerializeField] private float gainHealthBack = 1.5f;
    [HideInInspector] public float healthUpdate;
    [SerializeField] private float gamePlayLevelCount = 5;

    private float timeElapsed = 0f;
    public int enemiesAlive;
    bool keySpawned = false;

    public SpriteRenderer door;

    DifficultyManager difficultyManager;
    Health playerHealth;

    InputAction pauseMenu;

    private void Awake()
    {
        pauseScreen.SetActive(false);

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        playerHealth = FindFirstObjectByType<Health>();
        difficultyManager = FindFirstObjectByType<DifficultyManager>();
        pauseMenu = InputSystem.actions.FindAction("Pause Menu");

        gamblingMachine.SetActive(false);

        if (difficultyManager.currentDifficulty == Difficulty.Hard)
        {
            HealthPowerup();
        }

        //this below is temprary until i figure out how to get the currect difficulty from the "PlayerPrefs.GetInt("Difficulty", index)"
        PlayerPrefs.GetInt("Difficulty");
    }
    
    void Update()
    {
        TimeCounter();
        Menu();
        NextLevel();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (timeText != null)
        {
            return;
        }
        timeText = GameObject.FindWithTag("TimeText").GetComponent<TextMeshProUGUI>();

        playerHealth = FindFirstObjectByType<Health>();
        difficultyManager = FindFirstObjectByType<DifficultyManager>();

        keySpawned = false;

        if (scene.buildIndex < gamePlayLevelCount)
        {
            key.SetActive(false);
            powerup.SetActive(false);
            door.sprite = changeDoor[0];
            gamblingMachine.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    #region UI
    void TimeCounter()
    {
        timeElapsed += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    } 

    void Menu()
    {
        if (pauseMenu.WasPressedThisFrame())
        {
            if (pauseScreen.activeInHierarchy)
            {
                PauseGame(false);
            }
            else
            {
                PauseGame(true);
            }
        }
    }

    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

        if (status)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
 
    }
    #endregion
    #region Next Level
    private void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex < gamePlayLevelCount)
        {
            if (!keySpawned && enemiesAlive <= 0)
            {
                keySpawned = true;
                key.SetActive(true);
                door.sprite = changeDoor[1];
                gamblingMachine.SetActive(true);
            }
        }
    }
    #endregion
    #region Save Player Health
    void NextLevelHealth()
    {
        if (difficultyManager.currentDifficulty == Difficulty.Easy)
        {
            healthUpdate = playerHealth.maxHealth;
        }

        if (difficultyManager.currentDifficulty == Difficulty.Normal)
        {
            healthUpdate = Mathf.Min(playerHealth.currentHealth * gainHealthBack, healthUpdate);
        }

        if (difficultyManager.currentDifficulty == Difficulty.Hard)
        {
            healthUpdate = playerHealth.currentHealth;
        }
    }

    public void ApplyNewHealth()
    {
        StartCoroutine(ChangeHealth());
    }

    IEnumerator ChangeHealth()
    {
        healthUpdate = playerHealth.currentHealth;
        NextLevelHealth();

        yield return new WaitForSecondsRealtime(2.5f);
        playerHealth.SetHealth();
    }
    #endregion
    #region Health Powerup
    void HealthPowerup()
    {
        powerup.SetActive(true);
        Debug.Log("True");
    }
    #endregion
}