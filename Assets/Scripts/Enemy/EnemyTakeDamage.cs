using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyTakeDamage : MonoBehaviour
{
    DamageDealer damageDealer;

    void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
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
                damageDealer.GetDamage();
                Debug.Log("OW(im enemy");
            }   
        }
    }
}
