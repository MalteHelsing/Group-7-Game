using UnityEngine;
using UnityEngine.Rendering;
using static DifficultyManager;

public class HealthUpdate : MonoBehaviour
{
    public float currentHealth;
    public float newHealth;

    DifficultyManager difficultyManager;
    Health playerHealth;

    private void Start()
    {
        currentHealth = PlayerPrefs.GetString("Health", currentHealth);
    }

    void Update()
    {
        if (difficultyManager.currentDiffculty == Difficulty.Easy)
        {
            currentHealth = playerHealth.maxHealth;
        }

        if (difficultyManager.currentDiffculty == Difficulty.Normal)
        {
            newHealth = currentHealth * 1.5f;
            PlayerPrefs.SetFloat("newHealth", newHealth);
        }
    }
}
