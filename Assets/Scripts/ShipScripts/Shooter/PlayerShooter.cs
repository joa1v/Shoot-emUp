using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : ShooterScript
{
    [SerializeField] private ParticleSystem[] playerBullets;
    private int bulletID;

    /// GET E SET
    public int BulletID
    {
        get { return bulletID; }
        set { bulletID = value; }
    }

    public override void Update()
    {
        base.Update();

        SetBulletID();

        if (Input.GetMouseButtonDown(0))
            Shoot();

        if (Input.GetMouseButtonUp(0))
            StopShoot();
    }

    public void SetBulletID()
    {
        bullet = playerBullets[BulletID];
    }
}
