using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int damage = 10;

    InputAction attackAction;
    DamageDealer damageDealer;
    Health health;

    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        damageDealer = GetComponent<DamageDealer>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Debug.Log("OW");
            
        }
    }

    
}