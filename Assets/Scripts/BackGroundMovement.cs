using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    public float speed;
    public float maxY;
    public float initialY;
    public BackGroundElementSpawner spawner;

    private void Start()
    {
        if (GetComponentInParent<BackGroundElementSpawner>())
            spawner = GetComponentInParent<BackGroundElementSpawner>();
    }

    void Update()
    {
        Move();
        CheckPos();

    }

    public void Move()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);

    }

    public void CheckPos()
    {
        if (transform.position.y < maxY)
        {
            transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
            if (spawner)
            {
                gameObject.SetActive(false);
                spawner.activeElements--;
            }
        }
    }
}
