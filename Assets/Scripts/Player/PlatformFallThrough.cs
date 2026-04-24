using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformFallThrough : MonoBehaviour
{
    private void Update()
    {
        PressFall();
    }

    IEnumerator PressFall()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else if (Keyboard.current.sKey.wasReleasedThisFrame)
        {
            yield return new WaitForSeconds(1);
            GetComponent<Collider2D>().enabled = true;
        }
    }
}