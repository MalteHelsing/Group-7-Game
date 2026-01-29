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
        if (Mouse.current.leftButton.isPressed && damageDealer != null)
        {
            Damage();
            Debug.Log("OW");
        }
    }

    public int Damage()
    {
        return damageDealer.GetDamage();
    }
}