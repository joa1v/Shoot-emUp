using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private bool isPlayer;
    public GameObject[] playerBullets;
    public ParticleSystem bullet;
    private SFXPlayer sFXPlayer;
    //public int activebullet;

    void Start()
    {
        if (GetComponent<PlayerController>())
        {
            isPlayer = true;
            SetBullet(0);
        }

        if (GetComponent<SFXPlayer>())
            sFXPlayer = GetComponent<SFXPlayer>();
    }

    void Update()
    {
        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

            if (Input.GetMouseButtonUp(0))
            {
                StopShooting();
            }
        }

        if(bullet.isEmitting)
            if (sFXPlayer)
                sFXPlayer.PlayShootSFX();
    }

    public void SetBullet(int bulletID)
    {
        if(bulletID > 0)
            if (GetComponent<SFXPlayer>())
                GetComponent<SFXPlayer>().PlayPowerUPSFX();


        for (int i = 0; i < playerBullets.Length; i++)
        {
            if (bulletID == i)
                playerBullets[i].SetActive(true);
            else
                playerBullets[i].SetActive(false);

        }
        bullet = playerBullets[bulletID].GetComponent<ParticleSystem>();

    }

    public void Shoot()
    {
        bullet.Play();
    }

    public void StopShooting()
    {
        bullet.Stop();
    }
}

