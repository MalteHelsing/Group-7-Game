using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] GameObject key;

    private float timeElapsed = 0f;
    bool keySpawned = false;

    InputAction pauseMenu;

    private void Awake()
    {
        pauseScreen.SetActive(false);
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
            SpawnKey();
        }
    }

    void SpawnKey()
    {
        key.SetActive(true);
    }
    #endregion

}
