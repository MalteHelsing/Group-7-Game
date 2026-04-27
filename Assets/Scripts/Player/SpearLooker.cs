using UnityEngine;
using UnityEngine.InputSystem;
public class SpearLooker : MonoBehaviour
{
    public Camera mainCam;
    public Vector3 mousePos;

    public void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        MoveMouse();
    }

    public void MoveMouse()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }
}