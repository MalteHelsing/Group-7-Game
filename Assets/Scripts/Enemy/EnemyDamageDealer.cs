using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 5;

    public int GetDamage()
    {
        return damage;
    }
}