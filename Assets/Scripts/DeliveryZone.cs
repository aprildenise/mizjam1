using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{

    public GameObject objectToDeliver;
    private GameManager game;

    private void Start()
    {
        game = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(objectToDeliver))
        {
            OnTrigger();
        }
    }

    protected virtual void OnTrigger()
    {
        game.ShowVictory();
    }

}
