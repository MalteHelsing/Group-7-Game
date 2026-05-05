using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float currentHealth = 10f;
    public bool isGummba;
    public bool isSkeleton;
    public bool isBat;

    private void Start()
    {
        if (isGummba == true)
        {
            currentHealth = DifficultyManager.instance.enemyHealth;
        }
        if (isSkeleton == true)
        {
            currentHealth = DifficultyManager.instance.skeletonHealth;
        }
        if (isBat == true)
        {
            currentHealth = DifficultyManager.instance.batHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            int layerIndexC = LayerMask.NameToLayer("HitBox");

            if (other.gameObject.layer == layerIndexC)
            {
                TakeDamage(damageDealer.GetDamage());
            }
        }
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Dead");
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