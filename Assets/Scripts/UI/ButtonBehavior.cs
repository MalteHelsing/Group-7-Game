using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
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

    private GamblingMachine gamblingMachine;

    public void GamblingMachineMenuOn()
    {
        gamblingMachineMenu.SetActive(true);
    }

    public void GamblingMachineMenuOff()
    {
        gamblingMachineMenu.SetActive(false);
    }

    public void GamblingMachineMenu(bool staus)
    {
        gamblingMachineMenu.SetActive(staus);
    }

    public void GamblingMachineOn()
    {
        gamblingMachine.StartSpinning();
    }
    #endregion
}