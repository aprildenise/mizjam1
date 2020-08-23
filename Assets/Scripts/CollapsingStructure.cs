using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class CollapsingStructure : MonoBehaviour
{

    private GameManager game;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
        game.AddCollapsingStructure();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Environment") 
            || collision.gameObject.layer == LayerMask.NameToLayer("Collapsing")) return;

        float damage = GetChangeInPosition();

        if (damage > 10) return;

        // Clamp at a certain distance

        game.AddDamage(damage * 100f);
    }


    private float GetChangeInPosition()
    {
        return Vector3.Distance(startPosition, rb.position);
    }
}
