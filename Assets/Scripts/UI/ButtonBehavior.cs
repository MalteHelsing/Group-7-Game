using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    bool isOn;

    private void Start()
    {
        gamblingMachine = FindFirstObjectByType<GamblingMachine>();
        isOn = false;
    }

    #region Buttons
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Options()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Retry()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex);
    }

    public void StartMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
    #region Controls Menu
    [SerializeField] private GameObject ControlsMenu;

    public void ControlMenuOn()
    {
        ControlsMenu.SetActive(true);
    }

    public void ControlMenuOff()
    {
        ControlsMenu.SetActive(false);
    }

    public void PausGame(bool staus)
    {
        ControlsMenu.SetActive(staus);
    }
    #endregion
    #region Gambling Machine
    [SerializeField] private GameObject gamblingMachineMenu;

    GamblingMachine gamblingMachine;

    public void GamblingMachineMenuOn()
    {
        GamblingMachineMenu(true);
    }

    public void GamblingMachineMenuOff()
    {
        GamblingMachineMenu(false);
    }

    public void GamblingMachineMenu(bool staus)
    {
        gamblingMachineMenu.SetActive(staus);

        if (staus)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void GamblingMachineOn()
    {
        if (isOn == false)
        {
            StartCoroutine(gamblingMachine.StartSpinning());
            isOn = true;
        }
    }
    #endregion
    #region Change Player Design
    ChangePlayer changePlayer;
    private void GoLeft()
    {
        changePlayer.UpdatePlayerDesign(-1);
    }

    private void GoRigth()
    {
        changePlayer.UpdatePlayerDesign(+1);
    }
    #endregion
}