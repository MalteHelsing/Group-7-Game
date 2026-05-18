using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float health = 10f;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject deathMenu;
    private float currenthealth;

    EnemyDamageDealer enemyDamageDealer;
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        enemyDamageDealer = FindFirstObjectByType<EnemyDamageDealer>();
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();

        deathMenu.SetActive(false);

        spriteRenderer.enabled = true;

        currenthealth = health;
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
        if (currenthealth <= 0)
        {
            playerMovement.Death();
            spriteRenderer.enabled = false;
            deathMenu.SetActive(true);
        }
    }

    void TakeDamage(int enemyDamage)
    {
        currenthealth -= enemyDamage;

        FindFirstObjectByType<HealthBar>().UpdateHealthUI();

        if (currenthealth <= 0)
        {
            Die();
        }
    }

    public void Alive()
    {
        playerMovement.Alive();
        spriteRenderer.enabled = true;
        deathMenu.SetActive(false);
        currenthealth = health;
    }
    #endregion
}