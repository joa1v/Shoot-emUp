using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    [SerializeField] private float speed = 150;
    public GameObject shield;
    public bool autoEnableShield;
    [SerializeField] private float shieldCoolDown;
    private Rigidbody2D rb2d;
    [HideInInspector] public Vector2 screenSpace;
    private SpriteRenderer spriteRenderer;
    private bool shieldUP;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        screenSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
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

    public void EnableShield()
    {
        shield.SetActive(true);
    }


    public void StartAutoEnable()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(AutoEnableShield());
    }

    IEnumerator AutoEnableShield()
    {
        yield return new WaitForSeconds(shieldCoolDown);
        shield.SetActive(true);
    }

}
