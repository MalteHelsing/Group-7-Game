using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    DamageDealer damageDealer;

    void Start()
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

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
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
        return health;
    }
}
