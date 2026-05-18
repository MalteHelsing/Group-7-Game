using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float currentHealth = 10f;
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject deathMenu;

    public int health = 10;

    EnemyDamageDealer enemyDamageDealer;
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        enemyDamageDealer = FindFirstObjectByType<EnemyDamageDealer>();

        deathMenu.SetActive(false);
    }
    #region Damage
    private void OnTriggerEnter2D(Collider2D other)
    {
         enemyDamageDealer = other.GetComponent<EnemyDamageDealer>();

         if (enemyDamageDealer != null)
         { 
           TakeDamage(enemyDamageDealer.GetDamage());
         } 
    }

    public void Die()
    {
        playerMovement.Death();
        GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
        deathMenu.SetActive(true);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        FindFirstObjectByType<HealthBar>().UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    #endregion
}