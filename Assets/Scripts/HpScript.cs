using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public Slider hpBar;
    public ObjectPooler explosionVFXPooler;

    public EnemySpawnerScript spawner;

    public delegate void OnDeath();
    public event OnDeath onDeath;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer)
            originalColor = spriteRenderer.color;

    }

    private void OnEnable()
    {
        //se tiver uma barra de vida
        if (hpBar)
        {
            hpBar.gameObject.SetActive(true);
            hpBar.maxValue = maxHp;
        }

        if (spriteRenderer)  //reseta a cor quando morre
            spriteRenderer.color = originalColor;

        currentHp = maxHp;
    }

    private void Update()
    {
        if (hpBar)
            hpBar.value = currentHp;
    }

    public void TakeDamage(int _damageTaken)
    {
        currentHp -= _damageTaken;

        if (spriteRenderer)
        {
            spriteRenderer.color = Color.red;
            if (gameObject.activeInHierarchy)
                StartCoroutine(DisableRedColor());
        }

        if (currentHp <= 0)
            Die();
    }

    IEnumerator DisableRedColor()
    {
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = originalColor;

    }

    public void Die()
    {
        onDeath?.Invoke();

        //se é inimigo
        if (spawner)
        {
            EnemyDeath();
        }
        else if (GetComponentInParent<ShieldScript>() && !GetComponent<AimToTargetScript>())    // se for shield 
        {
            ShieldDeath();
        }
        else                                                                              //turrets basicamente
        {
            DefaultDeath();
        }

    }

    #region custom deaths
    public void EnemyDeath()
    {
        //retorna p pool
        spawner.objectPooler.GetBackToPool(gameObject);
        if (explosionVFXPooler && explosionVFXPooler.enemiesInst.Count > 0)
        {
            explosionVFXPooler.enemiesInst[0].transform.position = transform.position;
            explosionVFXPooler.enemiesInst[0].GetComponent<SelfDisableScript>().pool = explosionVFXPooler;
            explosionVFXPooler.enemiesInst[0].SetActive(true);
            explosionVFXPooler.enemiesInst.RemoveAt(0);
        }

        gameObject.SetActive(false);
    }


    public void ShieldDeath()
    {
        GetComponentInParent<ShieldScript>().DisableShield();

    }

    public void DefaultDeath()
    {
        gameObject.SetActive(false);
        if (explosionVFXPooler)
        {
            explosionVFXPooler.enemiesInst[0].transform.position = transform.position;
            explosionVFXPooler.enemiesInst[0].SetActive(true);
            explosionVFXPooler.enemiesInst.RemoveAt(0);
        }
    }

    #endregion

    private void OnDisable()
    {
        //reseta o hp quando morres
        currentHp = maxHp;

        //reseta a posição dos inimigos
        if (spawner)
            transform.position = spawner.transform.position;
    }

}
