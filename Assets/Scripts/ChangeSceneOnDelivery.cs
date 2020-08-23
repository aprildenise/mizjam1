using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnDelivery : DeliveryZone
{

    protected override void OnTrigger()
    {
        SceneManager.LoadScene(1);
    }
}
