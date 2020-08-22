using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Rigidbody2D target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public Vector2 xBounds;
    public Vector2 yBounds;
    private Vector3 velocity = Vector3.zero;

    public static CameraFollow instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, 0);
        Vector3 newPosition = targetPosition + offset;
        Vector3 clamp = new Vector3(Mathf.Clamp(newPosition.x, xBounds.x, xBounds.y),
            Mathf.Clamp(newPosition.y, yBounds.x, yBounds.y), newPosition.z);
        Vector3 smoothed = Vector3.SmoothDamp(transform.position, clamp, ref velocity, smoothSpeed);
        transform.position = smoothed;
    }
}