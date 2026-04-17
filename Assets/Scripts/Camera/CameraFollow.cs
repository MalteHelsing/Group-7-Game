using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    [SerializeField] float regularSmoothing = 0.6f;
    [SerializeField] float sKeySmoothing = 0.3f;
    [SerializeField] Vector3 offset = Vector3.zero;

    float smoothing = 0.6f;

    Vector3 velocity = Vector3.zero;
    Vector3 targetPosition;

    void Start()
    {
        FindTargetPosition();
    }

    private void Update()
    {
        FollowFaster();
    }

    void LateUpdate()
    {
        FindTargetPosition();

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothing);
    }

    void FindTargetPosition()
    {
        targetPosition = new Vector3(
            targetToFollow.position.x,
            targetToFollow.position.y,
            transform.position.z) + offset;
    }

    void FollowFaster()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            smoothing = sKeySmoothing;
        }
        else if (Keyboard.current.sKey.wasReleasedThisFrame)
        {
            smoothing = regularSmoothing;
        }
    }

}
