using TMPro;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    public TMP_Dropdown dropdown;
    public Difficulty currentDiffculty;

    [HideInInspector] public float enemyHealth;
    [HideInInspector] public float skeletonHealth;
    [HideInInspector] public float batHealth;
    [HideInInspector] public float enemyDamage;
    [HideInInspector] public float skeletonDamage;
    [HideInInspector] public float batDamage;

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
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
                enemyHealth = 5f;
                enemyDamage = 1f;
                break;

            case Difficulty.Normal:
                enemyHealth = 10f;
                enemyDamage = 2f;
                break;

            case Difficulty.Hard:
                enemyHealth = 20f;
                enemyDamage = 4f;
                break;
        }
    }

    // how to set the vaule in the script, which will sit under Start()
    // for example: damage = DifficultyManager.instance.enemyDamage; 

}