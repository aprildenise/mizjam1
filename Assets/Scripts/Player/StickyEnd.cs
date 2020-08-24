using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tentacle end of the octopus that controls when StickObjects stick to this.
/// </summary>
public class StickyEnd : MonoBehaviour
{
    public float interactionRadius;
    public LayerMask interactWith;

    private GameManager gameWorld;

    private void Start()
    {
        gameWorld = GameManager.instance;

        // Disable by default.
        this.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRadius, interactWith);
            foreach (Collider2D hit in hits)
            {
                StickyObject sticky = hit.GetComponent<StickyObject>();
                if (sticky == null) return;
                Transform stickyTransform = sticky.transform;

                // Make sure to only interact with objects that are unstuck and stuck on this tentacle.
                if (!sticky.stuckTo.Equals(null) && !sticky.stuckTo.Equals(transform) && !sticky.stuckTo.Equals(gameWorld.gameObject.transform)) continue;

                // If this object is already stuck, put it back in the world.
                if (sticky.isStuck)
                {
                    Debug.Log(sticky.gameObject.name + " set to unstuck");
                    stickyTransform.parent = gameWorld.gameObject.transform;
                    sticky.SetIsStuck(false, gameWorld.gameObject.transform);
                }
                // Attach this object as a child of this transform to make it stick to it.
                else
                {
                    Debug.Log(sticky.gameObject.name + " set to stuck on " + this.gameObject.name);
                    stickyTransform.parent = transform;
                    sticky.SetIsStuck(true, transform);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

}
