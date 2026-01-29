using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] int currentHealth = 50;

    DamageDealer damageDealer;
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        damageDealer = GetComponent<DamageDealer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            playerMovement.Death();
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
