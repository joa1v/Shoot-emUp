using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovementScript
{

    void Update()
    {
        ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }
}
