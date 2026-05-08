using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject[] hearts;
    [SerializeField] GameObject[] background;
    [SerializeField] float PlayerHealth = 1f;

    public Health playerHealth;

    public void UpdateHealthUI()
    {
        float health = playerHealth.currentHealth;

        float healthPerHearth = PlayerHealth / hearts.Length;
        int heartsToShow = Mathf.CeilToInt(health / healthPerHearth);

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < health);
            background[i].SetActive(1 >= heartsToShow);
        }
    }
}