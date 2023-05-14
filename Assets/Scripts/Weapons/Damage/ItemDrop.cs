using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[Serializable] public class LootItem
{
    public Item item;
    public int amount;
    public int dropChance;
}

[Serializable]
public class FromList
{
    public LootItem[] item;
    public int totalWeight;
    public int amountDropped;
}
public class ItemDrop : MonoBehaviour
{
    [SerializeField] public LootItem[] normal;
    [SerializeField] public FromList[] nFromList;
    public Inventory inventory;
    [HideInInspector] public int chance;
    private List<LootItem> AddedItems;


    private void Start()
    {
        if(inventory == null)
        {
            inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        }

        fun2(nFromList[0]);
    }
    
    public void Calculate()
    {
        Random r = new Random();
        chance = r.Next(0, 100);
    }

    public void CalculateForN(int weight)
    {
        Random r = new Random();
        chance = r.Next(0, weight);
    }

    public void DropItems()
    {
        foreach (LootItem item in normal)
        {
            Calculate();
            if (item.dropChance >= chance)
            {
                for (int j = 0; j < item.amount ; j++)
                {
                    inventory.AddItem(item.item);
                }
            }
        }
    }

    private int GetTableWeight(FromList table)
    {
        table.totalWeight = 0;   
        for (int j = 0; j < table.item.Length; j++)
        {
            table.totalWeight += table.item[j].dropChance;
        }

        return table.totalWeight;
    }

    private void fun2(FromList list)
    {
        int max = GetTableWeight(list);
        CalculateForN(max);
        
        
        GetItem(list);
    }

    private void GetItem(FromList list)
    {
        int chance3 = 0;
        Debug.Log(chance);
        
        for (int i = 0; i < list.item.Length; i++)
        {
            chance3 += list.item[i].dropChance;

            if (chance >= chance3)
            {
                Debug.Log(list.item[i].item);
            }
        }
    }
}
