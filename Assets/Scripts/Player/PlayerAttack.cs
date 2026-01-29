using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] bool isPlayer;

    DamageDealer damageDealer;

    private void Start()
    {
        damageDealer = FindFirstObjectByType<DamageDealer>();
    }
    private void Update()
    {
        if (isPlayer == true)
        {
            if (Keyboard.current.eKey.isPressed == true)
            {
                
            }
        }
    }
}