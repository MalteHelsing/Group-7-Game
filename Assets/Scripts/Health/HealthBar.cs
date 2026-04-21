using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    public Health playerHealth;

    void Update()
    {
        healthBar();
    }

    void healthBar()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < playerHealth.health);
        }
    }
}