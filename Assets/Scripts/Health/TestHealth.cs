using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestHealth : MonoBehaviour
{
    [SerializeField] int health = 50;

    Slider healthSlider;
<<<<<<< HEAD
=======

    InputAction jumpAction;
    
>>>>>>> db6d51574be3b5f3bf83c4b0d190dafe35320c9a

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