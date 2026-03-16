using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestHealth : MonoBehaviour
{
    TestHealth instance;

    public int maxHealth;
    int health;

    void Awake()
    {
        if (instance == null)
        {
            
        }
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage()
    {
        if (health <= 0)
        {
            return;
        }
        health -= 1;

        Debug.Log("TakeDamage");
    }

    void Update()
    {
        TakeDamage();
    }

    void TakeDamage(int damage)
    {
        health -= damage;
    }
}