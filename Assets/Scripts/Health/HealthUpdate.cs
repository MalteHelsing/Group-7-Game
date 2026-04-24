using UnityEngine;
using static DifficultyManager;

public class HealthUpdate : MonoBehaviour
{
    public float currentHealth;
    public float newHealth;

    DifficultyManager difficultyManager;
    Health playerHealth;

    private void Start()
    {
        
    }

    void Update()
    {
        if (difficultyManager.currentDiffculty == Difficulty.Easy)
        {
            playerHealth.currentHealth = playerHealth.maxHealth;
        }

        if (difficultyManager.currentDiffculty == Difficulty.Normal)
        {
            playerHealth.currentHealth * 1.5f = newHealth; 
        }
    }
}
