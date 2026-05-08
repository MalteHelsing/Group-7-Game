using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    int damage;
    public bool isGummba;
    public bool isSkeleton;
    public bool isBat;

    private void Start()
    {
        if (isGummba == true)
        {
            damage = DifficultyManager.instance.gombaDamage;
        }
        if (isSkeleton == true)
        {
            damage = DifficultyManager.instance.skeletonDamage;
        }
        if (isBat == true)
        {
            damage = DifficultyManager.instance.batDamage;
        }
    }

    public int GetDamage()
     {
        return damage;
     }
}
