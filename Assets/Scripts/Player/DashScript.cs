using UnityEngine;
using UnityEngine.InputSystem;

public class DashScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    Rigidbody2D rb2d;

    private void Start()
    {
        mainCam = Camera.main;
    }
    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    }
}
