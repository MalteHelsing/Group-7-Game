using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    [SerializeField] float smoothing = 0.6f;
    [SerializeField] Vector3 offset = Vector3.zero;

    [Header("CameraBounds")]
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float upBoundPadding;
    [SerializeField] float downBoundPadding;

    Vector3 velocity = Vector3.zero;
    Vector3 targetPosition;

    Vector2 minBounds;
    Vector2 maxBounds;

    void Start()
    {
        FindTargetPosition();
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

    void InitBounds()
    {
        Camera mainCamera = Camera.main;

        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
