using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [HideInInspector] public ShipScript ship;
    public ParticleSystem bullet;
    private SFXPlayer sFXPlayer;

    public void Start()
    {
        ship = GetComponent<ShipScript>();
        sFXPlayer = GetComponent<SFXPlayer>();
    }

    public virtual void Update()
    {
        if (sFXPlayer && bullet.isEmitting)
        {
            sFXPlayer.PlayShootSFX();
        }
    }

    public void Shoot()
    {
        bullet.Play();
    }

    public void StopShoot()
    {
        bullet.Stop();
    }

}
