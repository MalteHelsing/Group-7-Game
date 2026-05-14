using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    [SerializeField] float regularSmoothing = 0.6f;
    [SerializeField] float sKeySmoothing = 0.3f;
    [SerializeField] Vector3 offset = Vector3.zero;
    [SerializeField] Transform leftBound;
    [SerializeField] Transform rightBound;
    [SerializeField] Transform mainCamera;

    void Boundery()
    {
        if (leftBound.position.x < mainCamera.position.x -14f && rightBound.position.x > mainCamera.position.x +14f)
        {
            regularSmoothing = regularSmoothing * 0f;
        }
        else
        {
            regularSmoothing = regularSmoothing * 1f;
        }
    }

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
        Boundery();
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
