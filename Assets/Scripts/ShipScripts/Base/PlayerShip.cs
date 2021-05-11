using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : ShipScript
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();

        if (Input.GetMouseButtonUp(0))
            StopShoot();
    }
}
