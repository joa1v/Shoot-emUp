using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private ShipScript ship;

    private void Start()
    {
        ship = GetComponent<ShipScript>();
    }

    void Update()
    {
        ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }
}
