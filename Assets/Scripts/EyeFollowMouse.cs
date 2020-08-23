using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollowMouse : MonoBehaviour
{

    public float radius = 0.08f;
    public float smoothSpeed = 0.125f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 origin;

    private void Awake()
    {
        origin = transform.position;
    }

    private void LateUpdate()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPosition = target;
        Vector3 clamp = new Vector3(Mathf.Clamp(newPosition.x, origin.x - radius, origin.x + radius),
            Mathf.Clamp(newPosition.y, origin.y - radius, origin.y + radius), 0f);
        Vector3 smoothed = Vector3.SmoothDamp(transform.position, clamp, ref velocity, smoothSpeed);
        transform.position = smoothed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
