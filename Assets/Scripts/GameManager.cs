using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    [HideInInspector] public float healthUpdate;
    [SerializeField] private float gamePlayLevelCount = 5;

    private float timeElapsed = 0f;
    public int enemiesAlive;
    bool keySpawned = false;

    public SpriteRenderer door;

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
        pauseMenu = InputSystem.actions.FindAction("Pause Menu");
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
        if (key != null)
        {
            return;
        }

        timeText = GameObject.FindWithTag("TimeText").GetComponent<TextMeshProUGUI>();

        playerHealth = FindFirstObjectByType<Health>();

        keySpawned = false;

        if (scene.buildIndex < gamePlayLevelCount)
        {
            key.SetActive(false);
            powerup.SetActive(false);
            door.sprite = changeDoor[0];
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
            if (!keySpawned && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
            {
                keySpawned = true;
                key.SetActive(true);
                door.sprite = changeDoor[1];
            }
        }
    }
    #endregion
}