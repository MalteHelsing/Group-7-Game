using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float currentHealth = 10f;
    [SerializeField] bool isEnemy = false;

    DamageDealer damageDealer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            if (isEnemy != false)
            {
                int layerIndexC = LayerMask.NameToLayer("HitBox");

                if (other.gameObject.layer == layerIndexC)
                {
                    TakeDamage(damageDealer.GetDamage());
                }
            }
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
}
