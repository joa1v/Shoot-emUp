using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AimToTargetScript))]
public class MoveToTargetScript : MovementScript
{

    void Update()
    {
        Chase();

    }

    public void Chase()
    {

        ship.Move(transform.up.x, transform.up.y);
    }

}
