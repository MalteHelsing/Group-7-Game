using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    [SerializeField] float enemyProjectilePrefabDelay = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Ground"))
        {
            Destroy(other.gameObject, enemyProjectilePrefabDelay);

            Debug.Log("Hello");
        }
    }
}