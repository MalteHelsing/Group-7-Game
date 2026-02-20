using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class TestHealth : MonoBehaviour
{
    [SerializeField] bool isPlayer = false;
    [SerializeField] int scoreValue = 50;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitParticlePrefab;

    [SerializeField] bool applyCameraShake = false;

    float damageDealer;

    Slider healthSlider;
    
    
    

    void Start()
    {
        healthSlider.value = health;
        healthSlider = GetComponent<Slider>();
    }

    void Update()
    {
       
    }

    void HealthSlider()
    {
        healthSlider.value -= 10f;
    }
 
}