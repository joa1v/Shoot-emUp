using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightScript : MonoBehaviour
{
    public EnemySpawnerScript[] enemySpawner;
    public GameObject bossFightMusic;
    public GameObject levelMusic;
    public GameObject boss;
    public float timeToBossFight;
    void Start()
    {
        StartCoroutine(SpawnBoss());
    }

    public void StartBossFight()
    {
        boss.SetActive(true);
        bossFightMusic.SetActive(true);
        levelMusic.SetActive(false);
        for (int i = 0; i < enemySpawner.Length; i++)
        {
            enemySpawner[i].StopSpawn();
        }
    }

    public IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(timeToBossFight);
        StartBossFight();
    }
}
