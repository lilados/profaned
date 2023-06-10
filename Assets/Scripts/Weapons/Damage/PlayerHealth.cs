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


    public Slider healthBar;
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
        if (!regenBlocked && timeLeft == 0) Regenarate();


        healthBar.maxValue = maxHealth;
        healthBar.value = health;

    }

    private void Regenarate()
    {
        health += amountHealed;
        timeLeft = freq;
    }

    public void TakeDamage(int amount)
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
}
