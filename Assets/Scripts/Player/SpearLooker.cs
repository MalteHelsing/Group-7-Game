using UnityEngine;
using UnityEngine.InputSystem;

public class SpearLooker : MonoBehaviour
{
    private Camera camera;


    void Start()
    {
        camera = Camera.main;
    }


    void Update()
    {
        //looking script
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad - 90; //Offset this by 90 degrees

        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);

        Debug.DrawLine(transform.position, mousePos, Color.blue, Time.deltaTime);
    }
}
