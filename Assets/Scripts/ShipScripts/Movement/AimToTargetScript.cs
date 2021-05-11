using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimToTargetScript : MonoBehaviour
{
    public Transform target;
    
    void Update()
    {
        AimToTarget();
    }

    public void AimToTarget()
    {
        Vector3 norTar = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;

        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.rotation = rotation;
    }
}
