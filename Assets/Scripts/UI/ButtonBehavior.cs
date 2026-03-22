using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Options()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void StartMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
