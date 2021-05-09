using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDropScript : MonoBehaviour
{
    public int bulletID;
    public bool isShield;
    public ObjectPooler pooler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            gameObject.SetActive(false);

            if (!isShield)
            {
                collision.transform.GetComponent<Shooter>().SetBullet(bulletID);
                pooler.GetBackToPool(gameObject);
            }
            else
            {
                collision.GetComponent<ShieldScript>().EnableShield();
                pooler.GetBackToPool(gameObject);
            }

        }
    }
}
