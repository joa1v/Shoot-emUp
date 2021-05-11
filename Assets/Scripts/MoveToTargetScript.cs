using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AimToTargetScript))]
public class MoveToTargetScript : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb2d;
    public int collisionDamage;
    public float speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Chase();

    }

    public void Chase()
    {
        rb2d.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

}
