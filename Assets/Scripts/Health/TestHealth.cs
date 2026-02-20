using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestHealth : MonoBehaviour
{
    [SerializeField] int health = 50;

    Slider healthSlider;

    InputAction jumpAction;
    

    void Start()
    {
        healthSlider.value = health;
        healthSlider = GetComponent<Slider>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
       if (jumpAction.IsPressed())
       {
            HealthSlider();
       }
    }

    void HealthSlider()
    {
        healthSlider.value -= 10f;
    }
 
}