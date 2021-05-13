using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundElementSpawner : MonoBehaviour
{
    public GameObject[] backGroundElements;
    public int activeElements;
    public int maxActiveElements;
    void Start()
    {
        StartCoroutine(NextSpawn());
    }

    IEnumerator NextSpawn()
    {
        yield return new WaitForSeconds(5f);
        if (activeElements < maxActiveElements)
            Spawn(Random.Range(0, backGroundElements.Length));
        StartCoroutine(NextSpawn());

    }

    public void Spawn(int _id)
    {
        if (!backGroundElements[_id].activeInHierarchy)
        {
            backGroundElements[_id].SetActive(true);
            activeElements++;
        }
    }
}
