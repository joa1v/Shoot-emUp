using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private ShipScript ship;

    void Start()
    {
        ship = GetComponentInParent<ShipScript>();
    }

    private void OnDisable()
    {
        ship.StartAutoEnable();
    }
}
