using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDisableScript : MonoBehaviour
{
    public float selfDisableTime;
    [HideInInspector]public ObjectPooler pool;

    private void OnEnable()
    {
        StartCoroutine(SelfDisable());
    }

    IEnumerator SelfDisable()
    {
        yield return new WaitForSeconds(selfDisableTime);
        pool.GetBackToPool(gameObject);
        gameObject.SetActive(false);
    }
}
