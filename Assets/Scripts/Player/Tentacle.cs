using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private StickyEnd stickyEnd;
    public float moveSpeed;
    private float alteredSpeed;
    private Vector2 moveVelocity;
    private Vector2 mousePosition;
    private Vector2 direction;
    private GameManager game;

    private void Start()
    {
        game = GameManager.instance;
    }

    private void FixedUpdate()
    {
        if (game.isPaused)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        // Find where the mouse is to determine object movement.
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float magnitude = (mousePosition - (Vector2)rb.position).magnitude;
        direction = (mousePosition - (Vector2)rb.position).normalized;

        if (magnitude > 5f)
        {
            alteredSpeed = moveSpeed * (magnitude * .75f);
        }
        else
        {
            alteredSpeed = moveSpeed;
        }

        Debug.Log(alteredSpeed);

        // Smoothen movement and apply it to the rigidbody.
        moveVelocity = direction * alteredSpeed * Time.fixedDeltaTime;
        rb.velocity = moveVelocity;
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        stickyEnd.enabled = false;
    }

    private void OnEnable()
    {
        Debug.Log(gameObject.name + " is enabled.");
        stickyEnd.enabled = true;
    }
}
