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

    public void StartAutoEnable()
    {
        ship.StartAutoEnable();

    }
}
