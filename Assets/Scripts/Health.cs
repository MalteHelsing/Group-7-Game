using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] int currentHealth = 50;

    DamageDealer damageDealer;

    private void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void Damage(float damageAmount)
    {
        
    }
}
