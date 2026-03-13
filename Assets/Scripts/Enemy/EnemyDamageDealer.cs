using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 2;

    public int GetDamage()
    {
        return damage;
    }
}
