using Unity.Hierarchy;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float currentHealth = 10f;
    [SerializeField] int health = 10;
    [SerializeField] float damage = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentHealth = currentHealth - damage;

        Die();
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
