using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    Health playerHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //playerHealth.health * 1.5;
        }
    }
  

}