using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public bool autoActivate;
    public float autoActivateTime;
    public GameObject shield;
    private Coroutine coroutine;

    public void DisableShield()
    {
        if (autoActivate && coroutine == null)
            coroutine = StartCoroutine(ShieldUp());

        shield.SetActive(false);
        if (GetComponent<SFXPlayer>())
            GetComponent<SFXPlayer>().PlayDropSFX();
    }

    public void EnableShield()
    {
        shield.SetActive(true);
        if (GetComponent<SFXPlayer>())
            GetComponent<SFXPlayer>().PlayPowerUPSFX();
    }

    IEnumerator ShieldUp()
    {
        yield return new WaitForSeconds(autoActivateTime);
        EnableShield();
        coroutine = null;
    }
}
