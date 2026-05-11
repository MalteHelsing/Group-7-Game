using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    public TMP_Dropdown dropdown;
    public Difficulty currentDiffculty;

    [HideInInspector] public float gombaHealth;
    [HideInInspector] public float skeletonHealth;
    [HideInInspector] public float batHealth;
    [HideInInspector] public int gombaDamage;
    [HideInInspector] public int skeletonDamage;
    [HideInInspector] public int batDamage;

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
                gombaHealth = 5f;
                gombaDamage = 2;
                skeletonHealth = 2f;
                skeletonDamage = 5;
                batHealth = 2f;
                batDamage = 2;
                break;

            case Difficulty.Normal:
                gombaHealth = 10f;
                gombaDamage = 2;
                skeletonHealth = 5f;
                skeletonDamage = 10;
                batHealth = 4f;
                batDamage = 4;
                break;

            case Difficulty.Hard:
                gombaHealth = 20f;
                gombaDamage = 4;
                skeletonHealth = 10f;
                skeletonDamage = 20;
                batHealth = 8f;
                batDamage = 8;
                break;
        }
    }

    // how to set the vaule in the script, which will sit under Start()
    // for example: damage = DifficultyManager.instance.gombaDamage; 

}