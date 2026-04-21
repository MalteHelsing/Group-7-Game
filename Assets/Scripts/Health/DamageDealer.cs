using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 2;

    public int GetDamage()
    {
        return damage;
    }
}