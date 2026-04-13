using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject optionsScreen;
    private void Start()
    {
        optionsScreen.SetActive(false);
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

    public void ControlMenu()
    {
        if (optionsScreen.activeInHierarchy == true)
        {
            PausGame(false);
        }

        if (optionsScreen.activeInHierarchy == false)
        {
            PausGame(true);
        }
    }

    public void PausGame(bool staus)
    {
        optionsScreen.SetActive(staus);
    }
}
