using Unity.Hierarchy;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.VFX;

public class Health : MonoBehaviour
{
    [SerializeField] float currentHealth = 10f;
    [SerializeField] int health = 10;

    EnemyDamageDealer enemyDamageDealer;

    private void OnTriggerEnter2D(Collider2D other)
    {
         DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
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
