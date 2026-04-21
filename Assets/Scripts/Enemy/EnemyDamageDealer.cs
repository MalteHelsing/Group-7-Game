using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    int damage;

    private void Start()
    {
        damage = (int)DifficultyManager.instance.enemyDamage;
    }
    public int GetDamage()
    {
        return damage;
    }
}