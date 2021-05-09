using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HpScript))]
public class DropItemScript : MonoBehaviour
{
    private HpScript hpScript;
    public ObjectPooler[] drops;
    public float dropChance;
    private float drop;

    private void OnEnable()
    {
        drop = Random.Range(0f, 101f);
        hpScript = GetComponent<HpScript>();
        hpScript.onDeath += Drop;
    }

    private void OnDisable()
    {
        hpScript.onDeath -= Drop;

    }

    public void Drop()
    {
        //dropa um powerup aleatorio
        int dropID = Random.Range(0, drops.Length);

        if (drop <= dropChance && drops[dropID].enemiesInst.Count > 0)
        {
            drops[dropID].enemiesInst[0].transform.position = transform.position;
            drops[dropID].enemiesInst[0].SetActive(true);
            drops[dropID].enemiesInst.RemoveAt(0);
        }
    }
}
