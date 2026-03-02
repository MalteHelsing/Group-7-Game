using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    

    InputAction damageAction;

    Slider healthSlider;

    void Start()
    {
        damageAction = InputSystem.actions.FindAction("Crouch");
        
        healthSlider.value = health;
        healthSlider = GetComponent<Slider>();
    }

    void Update()
    {
      if (damageAction.IsPressed())
      {
            HealthSlider();
      }

      if (damageAction.IsPressed())
        {
            TakeDamage(2);
        }
    }

    void HealthSlider()
    {
        healthSlider.value -= 10f;
    }

    public void SetHealth (float currentHealth, float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
    // test health
    void TakeDamage(int damage)
    {
        health -= damage;
    }    
}