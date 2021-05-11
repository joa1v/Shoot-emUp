using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToShoot : ShooterScript
{
    public float shootCoolDown;

    private void OnEnable()
    {
        StartCoroutine(StartShoot());
    }

    public IEnumerator StartShoot()
    {
        yield return new WaitForSeconds(shootCoolDown);
        Shoot();
        StartCoroutine(StartShoot());
    }
}
