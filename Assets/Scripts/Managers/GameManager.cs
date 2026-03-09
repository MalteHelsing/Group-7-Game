using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    private float timeElapsed = 0f;

    InputAction pauseMenu;
    
    void Start()
    {
        pauseMenu = InputSystem.actions.FindAction("Pause Menu");
    }

    
    void Update()
    {
        TimeCounter();
        Menu();
    }

    void TimeCounter()
    {
        timeElapsed += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    } 

    void Menu()
    {
        if (pauseMenu.IsPressed())
        {
            if (pauseScreen.activeInHierarchy)
            {
                PausGame(false);
                Time.timeScale = 1;
            }
            else
            {
                PausGame(true);
                Time.timeScale = 0;
            }
        }
    }

    public void PausGame(bool staus)
    {

        pauseScreen.SetActive(staus);
    }
}
