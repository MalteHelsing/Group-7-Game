using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [Header("Key")]
    [SerializeField] float KeyPickUpDelay = 0.1f;
    [SerializeField] private GameObject keyIcon;
    [Header("Next level wait time")]
    [SerializeField] float nextLevelWaitTime = 1.5f;

    public bool HasKey = false;

    GameManager gameManager;

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
            StartCoroutine(SceneDelay());
            gameManager.SetHealth();
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

    IEnumerator SceneDelay()
    {
        
        yield return new WaitForSeconds(nextLevelWaitTime);
        LoadNextScene();
    }
}