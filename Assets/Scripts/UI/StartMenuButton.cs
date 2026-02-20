using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButton : MonoBehaviour
{
   public void StartMenu()
   {
        SceneManager.LoadSceneAsync(0);
   }
}
