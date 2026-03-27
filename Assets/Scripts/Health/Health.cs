using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float currentHealth = 10f;
    [SerializeField] int health = 10;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject deathMenu;

    EnemyDamageDealer enemyDamageDealer;
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;


    private void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        playerAttack = FindFirstObjectByType<PlayerAttack>();

        deathMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         EnemyDamageDealer enemyDamageDealer = other.GetComponent<EnemyDamageDealer>();

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

    public int GetHealth()
    {
        return health;
    }
}
