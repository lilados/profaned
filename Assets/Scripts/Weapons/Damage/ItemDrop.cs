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
    public List<LootItem> item;
    public int totalWeight;
    public int amountDropped;
}
public class ItemDrop : MonoBehaviour
{
    [SerializeField] public LootItem[] normal;
    [SerializeField] public FromList[] nFromList;
    [SerializeField]public Inventory inventory;
    [HideInInspector] public int chance;
    public List<LootItem> _addedItems;


    private void Start()
    {
        if(inventory == null)
        {
            inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        }
        
    }

    public void ManageDrops()
    {
        DropItems();
        foreach (FromList list in nFromList)
        {
            GetItem(list);
        }

        for (int j = 0; j < _addedItems.Count; j++)
        {
            for(int i = 0; i < _addedItems[j].amount; i++)
            {
                inventory.AddItem(_addedItems[j].item);
            }
        }
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
        for (int j = 0; j < table.item.Count; j++)
        {
            table.totalWeight += table.item[j].dropChance;
        }

        return table.totalWeight;
    }

    
    private void GetItem(FromList list)
    {
        int max = GetTableWeight(list);


        for (int j = 0; j < list.amountDropped; j++)
        {
            
            CalculateForN(max);
            int chance3 = 0;
            for (int i = 0; i < list.item.Count; i++)
            {
                chance3 += list.item[i].dropChance;

                if (chance <= chance3)
                {
                    
                    if (_addedItems.Contains(list.item[i]))
                    {
                        j--;
                    }
                    if (!_addedItems.Contains(list.item[i]))
                    {
                        max -= list.item[i].dropChance;
                        _addedItems.Add(list.item[i]);
                        list.item.Remove(list.item[i]);
                    }
                    break;
                }
            }
        }

    }
}
