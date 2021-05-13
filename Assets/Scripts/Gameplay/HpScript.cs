using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    [SerializeField] private int hp;
    private int curretHp;
    public int collisionDamage;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private SFXPlayer sFXPlayer;

    [SerializeField] private Slider hpBar;

    private void Start()
    {
        curretHp = hp;
        if (hpBar)
            hpBar.maxValue = hp;
        spriteRenderer = GetComponent<SpriteRenderer>();
        sFXPlayer = GetComponent<SFXPlayer>();
        if (spriteRenderer)
            originalColor = spriteRenderer.color;
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

        //reseta o hp
        curretHp = hp;
        //reseta a cor
        spriteRenderer.color = originalColor;

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
