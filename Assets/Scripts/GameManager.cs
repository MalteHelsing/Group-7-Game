using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static DifficultyManager;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI timeText;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject key;
    [SerializeFeild] private float gainHealthBack = 1.5f;
    [HideInInspector] public float healthUpdate;
    
    private float timeElapsed = 0f;
    bool keySpawned = false;

    DifficultyManager difficultyManager;
    Health playerHealth;

    InputAction pauseMenu;

    private void Awake()
    {
        pauseScreen.SetActive(false);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        pauseMenu = InputSystem.actions.FindAction("Pause Menu");
        key.SetActive(false);

    }
    
    void Update()
    {
        TimeCounter();
        Menu();
        NextLevel();
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
        if (!keySpawned && transform.childCount == 0)
        {
            keySpawned = true;
            key.SetActive(true);
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
}