using UnityEngine;
using UnityEngine.InputSystem;

public class Interactions : MonoBehaviour
{
    ButtonBehavior buttonBehavior;

    InputAction interactAction;

    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    #region Gambling Machine
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gambling Machine") && interactAction.IsPressed())
        {
            Debug.Log("yessir!!");
            buttonBehavior.GamblingMachineMenuOn();
        }
    }
    #endregion
}