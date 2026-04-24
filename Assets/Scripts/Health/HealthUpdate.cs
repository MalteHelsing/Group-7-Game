using UnityEngine;
using UnityEngine.Rendering;
using static DifficultyManager;

public class HealthUpdate : MonoBehaviour
{
    public float healthUpdate;
    public float currentHealth;
    public float newHealth;
    public float maxHealth;

    DifficultyManager difficultyManager;
    Health playerHealth;

    private void Start()
    {
        //string healthUpdate = PlayerPrefs.GetString("Health", currentHealth);
    }

    void Update()
    {
        if (difficultyManager.currentDiffculty == Difficulty.Easy)
        {
            healthUpdate = playerHealth.maxHealth;

        }

        if (difficultyManager.currentDiffculty == Difficulty.Normal)
        {
            newHealth = healthUpdate * 1.5f;
            PlayerPrefs.SetFloat("newHealth", newHealth);
        }
    }
}
