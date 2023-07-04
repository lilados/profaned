using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int baseHealth = 30;
    public float hpMult = 0f;
    public int maxHealth = 30;
    public int health = 30;
    
    [Space]
    [Header("Defense")
    ]public int baseDef;
    public float defMult;
    public int def;
    [Space]
    [Header("Regeneration")]public int amountHealed;
    public float freq, timeLeft;
    public bool regenBlocked;

    public float knockBackResistance;

    public Slider healthBar;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        
        maxHealth = (int)(baseHealth * (1 + hpMult));
        health = maxHealth;
        freq = 1.0f;
        timeLeft = freq;
    }

    private void Update()
    {
        maxHealth = (int)(baseHealth * (1 + hpMult));
        if (maxHealth < 0) maxHealth = 1;
        if(health <= 0) Destroy(gameObject);
        if (health > maxHealth) health = maxHealth;
        def = (int)(baseDef * (1+defMult));
        if (timeLeft > 0 && health != maxHealth) timeLeft -= Time.deltaTime;
        if (health == maxHealth) timeLeft = freq;
        if (timeLeft < 0) timeLeft = 0;
        if (!regenBlocked && timeLeft == 0) Regenerate();


        healthBar.maxValue = maxHealth;
        healthBar.value = health;

    }

    private void Regenerate()
    {
        health += amountHealed;
        timeLeft = freq;
    }

    public virtual void TakeDamage(int amount)
    {
        if(amount <= def)
        {
            health -= 1;
        }
        else
        {
            health -= amount - def;
        }
    }

    public virtual void TakeKnockBack(Vector2 knockForce)
    {
        if (knockBackResistance > -1)
        {
            knockForce /= (knockBackResistance + 1);
        }
        else
        {
            knockForce = new Vector2(0, 0);
        }
        gameObject.GetComponent<Rigidbody2D>().AddForce(knockForce, ForceMode2D.Impulse);

        StartCoroutine(ResetVelocity());
    }

    private IEnumerator ResetVelocity()
    {
        yield return new WaitForSeconds(0.2f);

        _rigidbody2D.velocity = Vector2.zero;
    }
}
