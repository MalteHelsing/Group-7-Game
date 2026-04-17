using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    public TMP_Dropdown dropdown;
    public Difficulty currentDiffculty;

    [HideInInspector] public float enemyHealth;
    [HideInInspector] public float enemySkeletDamage;
    [HideInInspector] public float enemyGumbaDamage;
    [HideInInspector] public float enemyBatDamage;
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            int savedIndex = PlayerPrefs.GetInt("Difficulty");
            currentDiffculty = (Difficulty)savedIndex;
            dropdown.value = savedIndex;
        }

        ApplyDiffculty();
    }

    public void SetDifficulty(int index)
    {
        currentDiffculty = (Difficulty)index;

        PlayerPrefs.SetInt("Difficulty", index);
        PlayerPrefs.Save();

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
    // for example: damage = DifficultyManager.instance.enemyBatDamage; 
}