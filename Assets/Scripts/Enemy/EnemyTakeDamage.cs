using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyTakeDamage : MonoBehaviour
{
    DamageDealer damageDealer;
    Health health;

    void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spear") && Mouse.current.leftButton.IsPressed())
        {
            if (damageDealer != null)
            {
                health.TakeDamage(damageDealer.GetDamage());
            }   
        }
    }
}
