using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] int currentHealth = 50;
    [SerializeField] bool isEnemy = false;

    DamageDealer damageDealer;
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        damageDealer = GetComponent<DamageDealer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (damageDealer != null && isEnemy)
        {
            TakeDamage(damageDealer.GetDamage());
        }

        else if (other.CompareTag("Enemy") && Mouse.current.leftButton.IsPressed())
        {
            if (damageDealer != null)
            {
                damageDealer.GetDamage();
            }
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
