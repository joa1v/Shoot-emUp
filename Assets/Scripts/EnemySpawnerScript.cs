using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPooler))]
public class EnemySpawnerScript : MonoBehaviour
{
    [HideInInspector] public ObjectPooler objectPooler;
    public float timeToSpawn;
    private bool canSpawn = true;
    public Transform target;
    public ObjectPooler[] dropsObjectPooler;
    public ObjectPooler explosionObjectPooler;

    void Start()
    {
        objectPooler = GetComponent<ObjectPooler>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeToSpawn);
        if (objectPooler.enemiesInst.Count > 0 && canSpawn)
        {
            AssignVars(objectPooler.enemiesInst[0]);

            objectPooler.enemiesInst[0].SetActive(true);
            objectPooler.enemiesInst.RemoveAt(0);
        }
        StartCoroutine(Spawn());
    }

    public void AssignVars(GameObject _spawnedObj)
    {
        if (_spawnedObj.GetComponent<HpScript>())
        {
            _spawnedObj.GetComponent<HpScript>().spawner = this;
            _spawnedObj.GetComponent<HpScript>().explosionVFXPooler = explosionObjectPooler;
        }
        if (_spawnedObj.GetComponent<AimToTargetScript>())
            _spawnedObj.GetComponent<AimToTargetScript>().target = target;
        if (_spawnedObj.GetComponent<MoveToTargetScript>())
            _spawnedObj.GetComponent<MoveToTargetScript>().target = target;

        if (_spawnedObj.GetComponent<DropItemScript>())
            _spawnedObj.GetComponent<DropItemScript>().drops = dropsObjectPooler;


    }

    public void StopSpawn()
    {
        canSpawn = false;
    }
}
