using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject objectToPool;
    public int amountToPool;
    [HideInInspector]public List<GameObject> enemiesInst = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject objInst = Instantiate(objectToPool, transform.position, transform.rotation);
            enemiesInst.Add(objInst);
            if (objInst.GetComponent<PowerUpDropScript>())
                objInst.GetComponent<PowerUpDropScript>().pooler = this;
            objInst.SetActive(false);
            objInst.transform.SetParent(transform);
        }
    }

    public void GetBackToPool(GameObject _gameObject)
    {
        enemiesInst.Add(_gameObject);
    }

}
