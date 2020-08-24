using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIOnDelivery : DeliveryZone
{

    public CanvasGroup canvas;

    private void Start()
    {
        game = GameManager.instance;
        canvas.gameObject.SetActive(false);
    }

    protected override void OnTrigger()
    {
        canvas.gameObject.SetActive(true);
        game.isPaused = true;
    }
}
