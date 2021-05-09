using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection
{
    HORIZONTAL,
    VERTICAL,

}

[RequireComponent(typeof(LimitPos))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemySideToSideMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private LimitPos limitPos;
    private bool moveRight = true;
    private bool moveuP = true;
    public float speed;
    public float margin;
    public int collisionDamage;
    public MovementDirection type;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        limitPos = GetComponent<LimitPos>();
    }

    private void Update()
    {
        if (type == MovementDirection.HORIZONTAL)
        {
            if (transform.position.x + margin >= limitPos.screenSpace.x)
                moveRight = false;

            if (transform.position.x - margin <= -limitPos.screenSpace.x)
                moveRight = true;
        }

        if (type == MovementDirection.VERTICAL)
        {
            if (transform.position.y + margin >= limitPos.screenSpace.y)
                moveuP = false;

            if (transform.position.y - margin <= -limitPos.screenSpace.y)
                moveuP = true;
        }

    }

    private void FixedUpdate()
    {
        if (type == MovementDirection.HORIZONTAL)
        {
            if (moveRight)
                Move(speed, 0);
            if (!moveRight)
                Move(-speed, 0);
        }


        if (type == MovementDirection.VERTICAL)
        {
            if (moveuP)
                Move(0, speed);
            if (!moveuP)
                Move(0, -speed);
        }
    }

    public void Move(float _x, float _y)
    {
        rb2d.MovePosition(new Vector2(rb2d.position.x + _x * Time.deltaTime, rb2d.position.y + _y * Time.deltaTime));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        collision.transform.GetComponent<HpScript>().TakeDamage(collisionDamage);
        GetComponent<HpScript>().TakeDamage(GetComponent<HpScript>().maxHp);

    }
}
