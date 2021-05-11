using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [HideInInspector]public ShipScript ship;

    private void Start()
    {
        ship = GetComponent<ShipScript>();
    }
}
