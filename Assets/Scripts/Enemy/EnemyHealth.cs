using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50f;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damageAmount = 10f)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
