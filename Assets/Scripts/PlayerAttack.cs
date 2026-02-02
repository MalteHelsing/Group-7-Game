using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    DamageDealer damageDealer;

    private void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed == true)
        {
            damageDealer.enabled = true;
        }
        else
        {
            damageDealer.enabled = false;
        }
    }
}
