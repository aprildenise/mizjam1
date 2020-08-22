using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed;
    private bool isMoving;
    private Vector2 moveVelocity;

    private GameManager game;

    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.isPaused)
        {
            moveVelocity = Vector2.zero;
            return;
        }

        // Get axis input for movement.
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        isMoving = moveInput != Vector2.zero;
        moveVelocity = moveInput.normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        // Apply movement.
        if (isMoving) rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
