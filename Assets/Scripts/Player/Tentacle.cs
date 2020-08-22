using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    public Vector2 verticalClamp;
    public Vector2 horizontalClamp;
    public float smoothThreshold;

    public float moveSpeed;
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
        direction = (mousePosition - (Vector2)rb.position).normalized;

        // Smoothen movement and apply it to the rigidbody.
        moveVelocity = direction * moveSpeed * Time.fixedDeltaTime;
        rb.velocity = moveVelocity;
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
    }
}
