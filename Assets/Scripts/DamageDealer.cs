using UnityEngine;
using UnityEngine.InputSystem;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public int GetDamage()
    {
        return damage;
    }
}
