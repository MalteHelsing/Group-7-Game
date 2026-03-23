using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestHealth : MonoBehaviour
{
    TestHealth instance;

    public int maxHealth;
    float currentHealth;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        if (currentHealth <= 0)
        {
            return;
        }
        currentHealth -= 1;

        Debug.Log("TakeDamage");
    }

    void Update()
    {
        TakeDamage();
    }

    public void MaxHealth()
    {
        currentHealth = 1;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}