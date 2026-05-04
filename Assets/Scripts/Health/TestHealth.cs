using UnityEngine;

public class TestHealth : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    float healthUpdate;
    float maxHealth;
    Health playerHealth;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<Health>();

        healthUpdate = playerHealth.currentHealth;
        maxHealth = playerHealth.maxHealth;
    }

    void Update()
    {
        HealthUpdateUI();
        
        healthUpdate = playerHealth.currentHealth;
    }

    void HealthUpdateUI()
    {
        if (healthUpdate == maxHealth)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(true);
        }
        else if (healthUpdate == maxHealth * 0.8f)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(false);
        }
        else if (healthUpdate == maxHealth * 0.6f)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (healthUpdate == maxHealth * 0.4f)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (healthUpdate == maxHealth * 0.2f)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (healthUpdate == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
    }
}