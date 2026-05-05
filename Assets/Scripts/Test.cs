using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    GameManager gameManager;

    InputAction interactAction;

    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GamblingMachine"))
        {
            if (interactAction.WasPressedThisFrame())
            {
                gameManager.gamblingMachine.SetActive(true);
            }
        }
    }
}