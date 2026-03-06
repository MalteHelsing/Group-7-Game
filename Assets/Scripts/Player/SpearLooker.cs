using UnityEngine;
using UnityEngine.InputSystem;

public class SpearLooker : MonoBehaviour
{
    public void SpearLookLeft()
    {
        transform.position = transform.position + new Vector3(-2, 0, 0);
    }

    public void SpearLookRight()
    {
        transform.position = transform.position + new Vector3(2, 0, 0);
    }
}