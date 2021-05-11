using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public int hp;
    public int collisionDamage;
    public ParticleSystem bullet;
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    [HideInInspector]public Vector2 screenSpace;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        screenSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    public void Shoot()
    {
        bullet.Play();
    }

    public void StopShoot()
    {
        bullet.Stop();
    }

    public void TakeDamage(int damageTaken)
    {
        hp -= damageTaken;
        if (hp <= 0)
            Die();
    }

    public void Move(float movex, float moveY)
    {
        LimitMovePos();

        Vector2 direction = new Vector2(movex, moveY);

        rb2d.velocity = direction * speed * Time.deltaTime;
    }


    public void LimitMovePos()
    {
        float halfSizeX = spriteRenderer.bounds.size.x / 2;
        float halfSizeY = spriteRenderer.bounds.size.y / 2;

        if (transform.position.x + halfSizeX > screenSpace.x)
            transform.position = new Vector3(screenSpace.x - halfSizeX, transform.position.y, transform.position.z);
        if (transform.position.x - halfSizeX < -screenSpace.x)
            transform.position = new Vector3(-screenSpace.x + halfSizeX, transform.position.y, transform.position.z);

        if (transform.position.y + halfSizeY > screenSpace.y)
            transform.position = new Vector3(transform.position.x, screenSpace.y - halfSizeY, transform.position.z);
        if (transform.position.y - halfSizeY < -screenSpace.y)
            transform.position = new Vector3(transform.position.x, -screenSpace.y + halfSizeY, transform.position.z);
    }


    public void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShipScript ship = collision.gameObject.GetComponent<ShipScript>();

        collision.gameObject.GetComponent<ShipScript>().TakeDamage(collisionDamage);

        TakeDamage(collision.gameObject.GetComponent<ShipScript>().collisionDamage);

    }
}
