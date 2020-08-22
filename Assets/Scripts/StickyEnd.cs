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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRadius, interactWith);
            foreach (Collider2D hit in hits)
            {
                StickyObject sticky = hit.GetComponent<StickyObject>();
                Transform stickyTransform = sticky.transform;

                // If this object is already stuck, put it back in the world.
                if (sticky.isStuck)
                {
                    stickyTransform.parent = gameWorld.gameObject.transform;
                    sticky.SetIsStuck(false);
                }
                // Attach this object as a child of this transform to make it stick to it.
                else
                {
                    Vector2 scale = stickyTransform.localScale;
                    Vector2 position = stickyTransform.localPosition;
                    Quaternion rotation = stickyTransform.localRotation;
                    stickyTransform.parent = transform;
                    sticky.SetIsStuck(true);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

}
