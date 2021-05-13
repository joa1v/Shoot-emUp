using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    [SerializeField] private int hp;
    [HideInInspector] public int curretHp;
    public int collisionDamage;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private SFXPlayer sFXPlayer;
    private ObjectPooler objectPooler;
    private ShieldScript shieldScript;
    [SerializeField] private Slider hpBar;

    private void Start()
    {
        curretHp = hp;
        if (hpBar)
            hpBar.maxValue = hp;

        spriteRenderer = GetComponent<SpriteRenderer>();
        sFXPlayer = GetComponent<SFXPlayer>();
        shieldScript = GetComponent<ShieldScript>();

        if (spriteRenderer)
            originalColor = spriteRenderer.color;

        objectPooler = ObjectPooler.Instance;

    }

    private void Update()
    {
        if (hpBar)
            hpBar.value = curretHp;
    }



    public void TakeDamage(int damageTaken)
    {
        curretHp -= damageTaken;

        if (gameObject.activeInHierarchy && spriteRenderer)
            StartCoroutine(SetColor(Color.red));


        if (curretHp <= 0)
            Die();
    }

    public void Die()
    {
        if (sFXPlayer)
            sFXPlayer.PlayExplosionSFX();

        //reseta a cor
        if (spriteRenderer)
            spriteRenderer.color = originalColor;

        if (shieldScript)
            shieldScript.StartAutoEnable();


        //reseta o hp
        curretHp = hp;

        objectPooler.SpawnFromPool("ExplosionVFX", transform.position, transform.rotation);

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HpScript ship = collision.gameObject.GetComponent<HpScript>();

        if (ship)
            ship.TakeDamage(collisionDamage);

        TakeDamage(ship.collisionDamage);

    }


    IEnumerator SetColor(Color _color)
    {
        spriteRenderer.color = _color;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = originalColor;
    }
}
