using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    [SerializeFeild] public TMP_Dropdown dropdown;
    [SerializeFeild] public Difficulty currentDiffculty;

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
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (PlayerPrefs.HasKey("Difficulty"))
            {
                int savedIndex = PlayerPrefs.GetInt("Difficulty");
                currentDiffculty = (Difficulty)savedIndex;
                dropdown.value = savedIndex;
            }
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
                enemyDamage = 2f;
                skeletonHealth = 2f;
                skeletonDamage = 5f;
                batHealth = 2f;
                batDamage = 2f;
                break;

            case Difficulty.Normal:
                enemyHealth = 10f;
                enemyDamage = 2f;
                skeletonHealth = 5f;
                skeletonDamage = 10f;
                batHealth = 4f;
                batDamage = 4f;
                break;

            case Difficulty.Hard:
                enemyHealth = 20f;
                enemyDamage = 4f;
                skeletonHealth = 10f;
                skeletonDamage = 20f;
                batHealth = 8f;
                batDamage = 8f;
                break;
        }
    }

    // how to set the vaule in the script, which will sit under Start()
    // for example: damage = DifficultyManager.instance.enemyDamage; 

}