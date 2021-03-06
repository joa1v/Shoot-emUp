using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection
{
    HORIZONTAL,
    VERTICAL,

}

public class EnemySideToSideMovement : MovementScript
{
    private bool moveRight = true;
    private bool moveuP = true;
    public MovementDirection type;

    [SerializeField] private float margin = .5f;

    private void Update()
    {
        if (type == MovementDirection.HORIZONTAL)
        {
            if (transform.position.x + margin >= ship.screenSpace.x)
                moveRight = false;

            if (transform.position.x - margin <= -ship.screenSpace.x)
                moveRight = true;
        }

        if (type == MovementDirection.VERTICAL)
        {
            if (transform.position.y + margin >= ship.screenSpace.y)
                moveuP = false;

            if (transform.position.y - margin <= -ship.screenSpace.y)
                moveuP = true;
        }

    }

    private void FixedUpdate()
    {
        if (ship)
        {
            if (type == MovementDirection.HORIZONTAL)
            {
                if (moveRight)
                    ship.Move(1, 0);
                if (!moveRight)
                    ship.Move(-1, 0);
            }


            if (type == MovementDirection.VERTICAL)
            {
                if (moveuP)
                    ship.Move(0, 1);
                if (!moveuP)
                    ship.Move(0, -1);
            }
        }

    }

}
