using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float currentHealth = 10f;
    [SerializeField] int health = 10;

    EnemyDamageDealer enemyDamageDealer;

    private void OnTriggerEnter2D(Collider2D other)
    {
         EnemyDamageDealer enemyDamageDealer = other.GetComponent<EnemyDamageDealer>();

        if (enemyDamageDealer != null)
        {
            TakeDamage(enemyDamageDealer.GetDamage());
        }

        Die();
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
