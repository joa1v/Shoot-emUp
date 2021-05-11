using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : ShooterScript
{

    public override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
            Shoot();

        if (Input.GetMouseButtonUp(0))
            StopShoot();
    }
}
