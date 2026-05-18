using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject[] hearts;
    [SerializeField] GameObject[] background;
    [SerializeField] float PlayerHealth = 100f;

    public Health playerHealth;
    private void Start()
    {
        playerHealth = GetComponent<Health>();
    }

    public void UpdateHealthUI()
    {
        if (playerHealth == null)
            return;

        float health = playerHealth.health;

        float healthPerHearth = PlayerHealth / hearts.Length;
        int heartsToShow = Mathf.CeilToInt(health / healthPerHearth);

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < health);
            background[i].SetActive(1 >= heartsToShow);
        }
    }
}