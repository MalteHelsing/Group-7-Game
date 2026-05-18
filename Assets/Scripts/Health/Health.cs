using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float currentHealth = 10f;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject deathMenu;

    EnemyDamageDealer enemyDamageDealer;
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        enemyDamageDealer = FindFirstObjectByType<EnemyDamageDealer>();

        deathMenu.SetActive(false);
    }
    private void Update()
    {
        Die();
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
        if (currentHealth <= 0)
        {
            playerMovement.Death();
            GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
            deathMenu.SetActive(true);
        }
    }

    void TakeDamage(int enemyDamage)
    {
        currentHealth -= enemyDamage;

        FindFirstObjectByType<HealthBar>().UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    #endregion
}