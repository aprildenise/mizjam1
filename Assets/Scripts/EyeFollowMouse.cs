using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollowMouse : MonoBehaviour
{

    public float radius = 0.08f;
    public float smoothSpeed = 0.125f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 origin;
    public float factor = 0.25f;

    private void Awake()
    {
        origin = transform.localPosition;
        //Debug.Log(origin);
    }

    private void LateUpdate()
    {

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0.0f;
        Vector3 dir = (transform.InverseTransformPoint(pos) - origin) * factor;
        dir = Vector3.ClampMagnitude(dir, radius);
        transform.localPosition = (origin + dir);


        //Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 newPosition = transform.InverseTransformPoint(target);
        ////Debug.Log(newPosition);
        //Vector3 clamp = new Vector3(Mathf.Clamp(newPosition.x, origin.x - radius, origin.x + radius),
        //    Mathf.Clamp(newPosition.y, origin.y - radius, origin.y + radius), 0f);
        //Vector3 smoothed = Vector3.SmoothDamp(origin, clamp, ref velocity, smoothSpeed);
        //Debug.Log(smoothed);
        //transform.localPosition = smoothed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
