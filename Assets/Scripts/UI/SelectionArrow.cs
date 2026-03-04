using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options; 
    private RectTransform rect;
    private int currentPosition;

    InputAction moveAction;

    private void Update()
    {
        if (moveAction.IsPressed())
        {

        }
    }

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        moveAction = InputSystem.actions.FindAction("Player/Move");
    }

    private void ChangePosition(int _change)
    {
        currentPosition += _change;

        if (currentPosition < 0)
        {
            currentPosition = options.Length - 1;
        }
        else if (currentPosition > options.Length - 1)
        {
            currentPosition = 0;
        }

        // the position of the arrow
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
    }
}
