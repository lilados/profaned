using System;
using UnityEngine;
using Random = System.Random;



public class HealthManager : MonoBehaviour
{
    [Header("Health")]
    public int baseHealth = 30;
    public float hpMult = 0f;
    public int maxHealth = 30;
    public int health = 30;
    
    [Space]
    [Header("Defense")]
    public int baseDef;
    public float defMult;
    public int def;
    [HideInInspector] public ItemDrop itemDrop;

    public int amountHealed;

    void Start()
    {
        maxHealth = (int)(baseHealth * (hpMult + 1));
        health = maxHealth;
        itemDrop = gameObject.GetComponent<ItemDrop>();
    }

    public void TakeDamage(int amount)
    {
        itemDrop.Calculate();
        health -= amount;
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        itemDrop.ManageDrops();
        if (CompareTag("Mineral"))
        {
            Destroy(gameObject);
        }
    }
}

