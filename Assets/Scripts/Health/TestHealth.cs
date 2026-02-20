using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class TestHealth : MonoBehaviour
{
    [SerializeField] bool isPlayer = false;
    [SerializeField] int scoreValue = 50;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitParticlePrefab;

    [SerializeField] bool applyCameraShake = false;

    float damageDealer;
    
    

    void Start()
    {
       
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            
        }

        Destroy(gameObject);
    }

    void PlayHitParticles()
    {
        if (hitParticlePrefab != null)
        {
            ParticleSystem particles = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }

    public int GetHealth()
    {
        return health;
    }
}