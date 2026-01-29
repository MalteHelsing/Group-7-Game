using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int damage = 10;

    InputAction attackAction;

    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Debug.Log("OW");
            GetDamage();
        }
    }

    public int GetDamage()
    {
        return damage;
    }
}