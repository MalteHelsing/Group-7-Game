using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeFeild] public float powerupValue = 10f;

    Health playerHealth;
    GameManager gameManager;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.currentHealth = playerHealth.currentHealth + powerupValue;
            Destroy(gameManager.powerup);
        }
    }
}