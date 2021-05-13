using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightScript : MonoBehaviour
{
    [SerializeField] private float timeToBossFight;
    [SerializeField] private GameObject[] bossFightElements;
    [SerializeField] private GameObject[] elementsToDesactive;

    private void Start()
    {
        StartCoroutine(StartBossFight());
    }

    IEnumerator StartBossFight()
    {
        yield return new WaitForSeconds(timeToBossFight);
        ActiveElements();
        DesactiveElements();
    }

    private void ActiveElements()
    {
        for (int i = 0; i < bossFightElements.Length; i++)
        {
            bossFightElements[i].SetActive(true);
        }
    }

    private void DesactiveElements()
    {
        for (int i = 0; i < elementsToDesactive.Length; i++)
        {
            elementsToDesactive[i].SetActive(false);
        }
    }
}
