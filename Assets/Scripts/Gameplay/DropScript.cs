using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DropType
{
    BULLET,
    SHIELD,

}

public class DropScript : MonoBehaviour
{
    [SerializeField] private int powerUpID;
    [SerializeField] private DropType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerShooter playerShooter = collision.GetComponent<PlayerShooter>();
        PlayerShip playerShield = collision.GetComponent<PlayerShip>();

        if (playerShooter && type == DropType.BULLET)
            playerShooter.BulletID = powerUpID;

        if (playerShield && type == DropType.SHIELD)
            playerShield.EnableShield();

        gameObject.SetActive(false);

    }
}
