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

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] public GameObject powerup;
    [SerializeField] public Sprite[] changeDoor;  
    [SerializeField] private float gainHealthBack = 1.5f;
    [HideInInspector] public float healthUpdate;
    
    private float timeElapsed = 0f;
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
    }
    
    void Update()
    {
        TimeCounter();
        Menu();
        NextLevel();
        HealthPowerup();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        timeText = FindFirstObjectByType<TextMeshProUGUI>();

        playerHealth = FindFirstObjectByType<Health>();
        difficultyManager = FindFirstObjectByType<DifficultyManager>();

        keySpawned = false;

        if (scene.buildIndex < 5)
        {
            key.SetActive(false);
            powerup.SetActive(false);
            door.sprite = changeDoor[0];
        }
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
                PausGame(false);
            }
            else
            {
                PausGame(true);
            }
        }
    }

    public void PausGame(bool staus)
    {
        pauseScreen.SetActive(staus);

        if (staus)
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
        if(SceneManager.GetActiveScene().buildIndex < 5)
        {
            if (!keySpawned && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                keySpawned = true;
                key.SetActive(true);
                door.sprite = changeDoor[1];
            }
        }
    }
    #endregion
    #region Save Player Health
    void HealthUpdate()
    {
        if (difficultyManager.currentDiffculty == Difficulty.Easy)
        {
            healthUpdate = playerHealth.maxHealth;
        }

        if (difficultyManager.currentDiffculty == Difficulty.Normal)
        {
            healthUpdate = playerHealth.currentHealth * gainHealthBack;
        }

        if (difficultyManager.currentDiffculty == Difficulty.Hard)
        {
            healthUpdate = playerHealth.currentHealth;
        }
    }

    public void SetHealth()
    {
        StartCoroutine(ChangeHealth());
    }

    IEnumerator ChangeHealth()
    {
        healthUpdate = playerHealth.currentHealth;
        HealthUpdate();

        yield return new WaitForSeconds(2.5f);
        playerHealth.SetHealth();
    }
    #endregion
    #region Health Powerup
    void HealthPowerup()
    {
        if (difficultyManager.currentDiffculty == Difficulty.Hard)
        {
            powerup.SetActive(true);
            Debug.Log("True");
        }
    }
    #endregion
}