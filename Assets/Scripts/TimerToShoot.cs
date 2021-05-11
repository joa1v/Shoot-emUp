using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipScript))]
public class TimerToShoot : MonoBehaviour
{
    private ShipScript ship;
    public float shootCoolDown;

    private void OnEnable()
    {
        ship = GetComponent<ShipScript>();
        StartCoroutine(StartShoot());
    }

    public IEnumerator StartShoot()
    {
        yield return new WaitForSeconds(shootCoolDown);
        ship.Shoot();
        StartCoroutine(StartShoot());
    }
}
