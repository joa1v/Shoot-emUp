using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteAmmoScript : MonoBehaviour
{
    public float timeToEndAmmo;

    private void OnEnable()
    {
        StartCoroutine(SelfDisable());
    }

    public void EndPowerUpAmmo()
    {
        GetComponentInParent<Shooter>().SetBullet(0);
        if (GetComponentInParent<SFXPlayer>())
            GetComponentInParent<SFXPlayer>().PlayDropSFX();
    }

    public IEnumerator SelfDisable()
    {
        yield return new WaitForSeconds(timeToEndAmmo);
        EndPowerUpAmmo();
    }
}
