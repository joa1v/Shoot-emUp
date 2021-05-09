using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    private Animator animator;
    public float speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x == 0)
        {
            animator.SetBool("moveRight", false);
            animator.SetBool("moveLeft", false);
        }
        else if (x > 0)
        {
            animator.SetBool("moveRight", true);
            animator.SetBool("moveLeft", false);
        }
        else if (x < 0)
        {
            animator.SetBool("moveRight", false);
            animator.SetBool("moveLeft", true);
        }

        Vector2 direction = new Vector2(x, y);
        rb2d.velocity = direction * speed * Time.deltaTime;
    }

   
}
