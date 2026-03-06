using UnityEngine;

public class SpearLooker : MonoBehaviour
{
    public void SpearLookLeft()
    {
        transform.position += new Vector3(-3, 0, 0);
    }

    public void SpearLookRight()
    {
        transform.position += new Vector3(3, 0, 0);
    }
}