using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    public Difficulty currentDiffculty;

    public float enemyHealth;
    public float enemySkeletDamage;
    public float enemyGumbaDamage;
    public float enemyBatDamage;
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ApplyDiffculty();
    }

    void ApplyDiffculty()
    {
        switch (currentDiffculty)
        {
            case Difficulty.Easy:
                enemyHealth = 2f;
                enemyBatDamage = 1f;
                enemyGumbaDamage = 1f;
                enemySkeletDamage = 1f;
                break;

            case Difficulty.Normal:
                enemyHealth = 5f;
                enemyBatDamage = 2f;
                enemyGumbaDamage = 2f;
                enemySkeletDamage = 2f;
                break;

            case Difficulty.Hard:
                enemyHealth = 10f;
                enemyBatDamage = 5f;
                enemyGumbaDamage = 5f;
                enemySkeletDamage = 5f;
                break;
        }
    }

    // how to set the vaule in the script, which will sit under Start()
    // damage = DifficultyManager.instance.enemyDamage; 
}