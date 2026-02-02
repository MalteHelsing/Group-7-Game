using UnityEngine;

public class DamageDealer : MonoBehaviour
{
   [SerializeField] int damageAmount = 10;

    public int GetDamage()
    {
        return damageAmount;
    }
}
