using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StickyObject : MonoBehaviour
{

    public bool isStuck;
    private Rigidbody2D rb;

    private void Start()
    {
        SetIsStuck(false);
    }

    public void SetIsStuck(bool isStuck)
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
        this.isStuck = isStuck;
    }



    //private void Start()
    //{
    //    isStuck = false;
    //    gameWorld = GameManager.instance;
    //    //rb = GetComponent<Rigidbody2D>();
    //    collider = transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>();
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    ToggleSticky(collision);
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    ToggleSticky(collision);
    //}

    //private void ToggleSticky(Collider2D collision)
    //{
    //    //Debug.Log("Caught something");
    //    if (collision.GetComponent<StickyEnd>() != null)
    //    {
    //        Debug.Log("Caught the sticky end");
    //        if (Input.GetKeyDown(KeyCode.Mouse0))
    //        {
    //            if (isStuck)
    //            {

    //            }
    //            else
    //            {
    //            }
    //        }
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
}
