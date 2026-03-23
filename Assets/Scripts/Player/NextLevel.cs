using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [Header("Key")]
    [SerializeField] float KeyPickUpDelay = 0.1f;

    public bool HasKey = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key") && HasKey == false)
        {
            HasKey = true;
            Destroy(other.gameObject, KeyPickUpDelay);
            Debug.Log("Key");
        }
        else if (other.CompareTag("Door") && HasKey == true)
        {
            HasKey = false;
            LoadNextScene();
            Debug.Log("Next Level");
        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
