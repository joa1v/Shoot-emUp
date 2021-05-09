using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LimitPos : MonoBehaviour
{
    private bool isPlayer;
    private SpriteRenderer spriteRenderer;
    [HideInInspector] public Vector2 screenSpace;
    [HideInInspector] public float halfSizeX;
    [HideInInspector] public float halfSizeY;

    void Start()
    {
        if (GetComponent<PlayerController>())
            isPlayer = true;
        screenSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        LimitPosition();
    }

    private void LimitPosition()
    {
        halfSizeX = spriteRenderer.bounds.size.x / 2;
        halfSizeY = spriteRenderer.bounds.size.y / 2;

        if (isPlayer)
        {
            if (transform.position.x + halfSizeX > screenSpace.x)
                transform.position = new Vector3(screenSpace.x - halfSizeX, transform.position.y, transform.position.z);
            if (transform.position.x - halfSizeX < -screenSpace.x)
                transform.position = new Vector3(-screenSpace.x + halfSizeX, transform.position.y, transform.position.z);

            if (transform.position.y + halfSizeY > screenSpace.y)
                transform.position = new Vector3(transform.position.x, screenSpace.y - halfSizeY, transform.position.z);
            if (transform.position.y - halfSizeY < -screenSpace.y)
                transform.position = new Vector3(transform.position.x, -screenSpace.y + halfSizeY, transform.position.z);
        }
    }
}
