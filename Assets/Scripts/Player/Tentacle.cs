using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private StickyEnd stickyEnd;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Material active; // Material to show when this script is enabled.
    [SerializeField] private Material inactive; // Material to show when this script is disabled.
    public float moveSpeed;
    private float alteredSpeed;
    private Vector2 moveVelocity;
    private Vector2 mousePosition;
    private Vector2 direction;
    private GameManager game;

    private void Start()
    {
        game = GameManager.instance;
        sprite.material = inactive;
    }


    /// <summary>
    /// Get mouse movement to move this tentacle.
    /// </summary>
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

        // Alter the speed of the tentacle so that it moves faster when further away.
        if (magnitude > 5f)
        {
            alteredSpeed = moveSpeed * (magnitude * .75f);
        }
        else
        {
            alteredSpeed = moveSpeed;
        }

        // Smoothen movement and apply it to the rigidbody.
        moveVelocity = direction * alteredSpeed * Time.fixedDeltaTime;
        rb.velocity = moveVelocity;
    }

    /// <summary>
    /// "Turn off" this tentacle when the script is not active, by resetting its velocity, changing its shader, and
    /// turning off its stickyEnd.
    /// </summary>
    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        sprite.material = inactive;
        stickyEnd.enabled = false;
    }


    /// <summary>
    /// "Turn on" this tentacle.
    /// </summary>
    private void OnEnable()
    {
        Debug.Log(gameObject.name + " is enabled.");
        sprite.material = active;
        stickyEnd.enabled = true;
    }
}
