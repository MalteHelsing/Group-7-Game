using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformFallThrough : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else if (Keyboard.current.sKey.wasReleasedThisFrame)
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }
}