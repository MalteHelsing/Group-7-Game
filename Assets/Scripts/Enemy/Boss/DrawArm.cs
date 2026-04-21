using UnityEngine;

public class DrawArm : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] GameObject hand;
    
    void Update()
    {
        lineRenderer.SetPosition(1, hand.transform.position);
    }
}