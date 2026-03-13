using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.XR;
public class SpearLooker : MonoBehaviour
{
    [SerializeField] float maxSpeed = 1f;

    InputAction fireAction;
    private void Update()
    {
        Vector3 position = transform.position;
        Vector3 direction;
        transform.Translate(Vector3.up * maxSpeed * Time.deltaTime * inputDevice.LeftStickY, Space.World);
        transform.Translate(Vector3.right * maxSpeed * Time.deltaTime * , Space.World);
        direction = transform.position - position;
    }
}