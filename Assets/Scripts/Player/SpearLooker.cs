using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class SpearLooker : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Mouse.current.leftButton.isPressed)
        {
            transform.LookAt(worldPos);
        }
    }
}