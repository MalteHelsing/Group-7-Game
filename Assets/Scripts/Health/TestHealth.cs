using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class TestHealth : MonoBehaviour
{
    [SerializeField] int health = 50;

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