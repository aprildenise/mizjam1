using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleController : MonoBehaviour
{

    public Tentacle[] tentacles;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            tentacles[0].enabled = true;
        }
        else
        {
            tentacles[0].enabled = false;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            tentacles[1].enabled = true;
        }
        else
        {
            tentacles[1].enabled = false;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            tentacles[2].enabled = true;
        }
        else
        {
            tentacles[2].enabled = false;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            tentacles[3].enabled = true;
        }
        else
        {
            tentacles[3].enabled = false;
        }
    }

}
