using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class HealthManager : MonoBehaviour
{
    public LootItem[] possibleItems;
    public Inventory inventory;
    [Space][Space]
    [HideInInspector] public int chance;

    [Header("Health Stats")] 
    public int baseHealth;
    public float healthMult;
    public int health;
    public int maxHealth;
    [Space]
    [Header("Defense Stats")]
    public int def;

    void Start()
    {
        maxHealth = (int)(baseHealth * (healthMult + 1));
        health = maxHealth;
        if(inventory == null)
        {
            inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        }
    }

    private void Calculate()
    {
        Random r = new Random();
        chance = r.Next(0, 100);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            int i = 0;
            foreach (LootItem item in possibleItems)
            {
                Calculate();
                if (item.dropChance >= chance)
                {
                    for (int j = 0; j < item.amount ; j++)
                    {
                        inventory.AddItem(item.item);
                    }
                }
                i++;
            }
            
            Destroy(gameObject);
        }
    }
}
