using UnityEngine;
using static DifficultyManager;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeFeild] float powerupValue = 10f;
    [SerializeFeild] GameObject powerup;

    DifficultyManager difficultyManager;
    Health playerHealth;

    private void Start()
    {
        if (difficultyManager.currentDiffculty == Difficulty.Hard)
        {
            powerup.SetActive(true);
        }
        else
        {
            powerup.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.currentHealth = playerHealth.currentHealth + powerupValue;
            Destroy(powerup);
        }
    }
}