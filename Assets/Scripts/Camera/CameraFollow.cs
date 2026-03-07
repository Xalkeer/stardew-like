using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Position")]
    [SerializeField] private Vector2 offset = Vector2.zero;
    [SerializeField] private float cameraZ = -10f; // En 2D, la camera est souvent a -10

    [Header("Smoothing")]
    [SerializeField] private float smoothTime = 0.15f;
    [SerializeField] private float maxSpeed = 50f;

    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            cameraZ
        );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref _velocity,
            smoothTime,
            maxSpeed
        );
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        _velocity = Vector3.zero;
    }
}