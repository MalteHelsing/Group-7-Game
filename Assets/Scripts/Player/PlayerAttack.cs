using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    
    DamageDealer damageDealer;
    InputAction attackAction;

    void Start()
    {
        damageDealer = FindFirstObjectByType<DamageDealer>();
        attackAction = InputSystem.actions.FindAction("Attack");
    }
    void Update()
    {
        Attacking();
    }

    void Attacking()
    {
        if (attackAction.IsPressed())
        {
            damageDealer.GetDamage();
        }
    }
}