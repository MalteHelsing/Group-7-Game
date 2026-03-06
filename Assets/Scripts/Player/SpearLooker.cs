using UnityEngine;
using UnityEngine.InputSystem;

public class SpearLooker : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition = Camera.main.transform.InverseTransformPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}