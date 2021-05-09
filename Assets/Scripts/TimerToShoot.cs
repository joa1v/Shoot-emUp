using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class TimerToShoot : MonoBehaviour
{
    private Shooter shooter;
    public float shootCoolDown;

    private void OnEnable()
    {
        shooter = GetComponent<Shooter>();
        StartCoroutine(StartShoot());
    }

    public IEnumerator StartShoot()
    {
        yield return new WaitForSeconds(shootCoolDown);
        shooter.Shoot();
        StartCoroutine(StartShoot());
    }
}
