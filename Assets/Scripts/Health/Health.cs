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
    PlayerAttack playerAttack;

    private void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        playerAttack = FindFirstObjectByType<PlayerAttack>();
        enemyDamageDealer = FindFirstObjectByType<EnemyDamageDealer>();

        deathMenu.SetActive(false);

        currentHealth = maxHealth;
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
            playerAttack.SpearAttack();
            GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
            deathMenu.SetActive(true);
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
    #endregion

    public void SetHealth()
    {
        currentHealth = GameManager.instance.healthUpdate;
    }
    public int GetHealth()
    {
        return health;
    }
}