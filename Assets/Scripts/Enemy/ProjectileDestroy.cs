using System.Security.Cryptography;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    [SerializeField] float enemyProjectilePrefabDelay = 1f;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Ground"))
        {
            Destroy(other.gameObject, enemyProjectilePrefabDelay);

            Debug.Log("Hello");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
