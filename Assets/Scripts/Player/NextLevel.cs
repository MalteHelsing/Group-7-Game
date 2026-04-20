using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [Header("Key")]
    [SerializeField] float KeyPickUpDelay = 0.1f;
    [SerializeField] private GameObject keyIcon;

    public bool HasKey = false;

    private void Start()
    {
        keyIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key") && HasKey == false)
        {
            HasKey = true;
            Destroy(other.gameObject, KeyPickUpDelay);
            keyIcon.SetActive(true);
        }
        else if (other.CompareTag("Door") && HasKey == true)
        {
            HasKey = false;
            keyIcon.SetActive(false);
            LoadNextScene();
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
