using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StickyObject : MonoBehaviour
{

    public bool isStuck;
    public Transform stuckTo;
    private Rigidbody2D rb;

    private void Start()
    {
        SetIsStuck(false, null);
    }

    public void SetIsStuck(bool isStuck, Transform stuckTo)
    {
        // If we are making this object stuck, then remove the rigibody (if it has one already).
        if (isStuck)
        {
            if (rb != null)
            {
                Rigidbody2D destroyThis = rb;
                rb = null;
                Destroy(destroyThis);
            }
        }
        // If we are making this object unstuck, add a rigidbody.
        else
        {
            if (GetComponent<Rigidbody2D>() == null) rb = gameObject.AddComponent<Rigidbody2D>();
        }

        // Apply the stuck to.
        if (stuckTo != null)
        {
            this.stuckTo = stuckTo;
        }

        this.isStuck = isStuck;
    }
}
