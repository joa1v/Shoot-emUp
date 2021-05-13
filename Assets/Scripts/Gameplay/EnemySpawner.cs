using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private ObjectPooler objectPooler;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private string objectToSpawn;
    [SerializeField] private Transform target;


    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeToSpawn);

        GameObject objInst = objectPooler.SpawnFromPool(objectToSpawn, transform.position, transform.rotation);
        if (objInst.GetComponent<AimToTargetScript>())
            objInst.GetComponent<AimToTargetScript>().target = target;


        StartCoroutine(Spawn());
    }

}
