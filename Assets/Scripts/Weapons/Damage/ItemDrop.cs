using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[Serializable] public class LootItem
{
    public Item item;
    public int quantity, maxQuantity;
    public int dropChance;
}

[Serializable]
public class FromList
{
    public List<LootItem> item;
    public int totalWeight;
    public int baseQuantity;
}
public class ItemDrop : MonoBehaviour
{
    [SerializeField] public LootItem[] normal;
    [SerializeField] public FromList[] nFromList;
    [SerializeField]public Inventory inventory;
    [HideInInspector] public int chance;
    public List<LootItem> _addedItems;


    private void Awake()
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
            if (_addedItems[j].maxQuantity == 0 || _addedItems[j].maxQuantity == _addedItems[j].quantity)
            {
                for(int i = 0; i < _addedItems[j].quantity; i++) {
                    inventory.AddItem(_addedItems[j].item);
                }
                Debug.Log("= or 0");
            }
            else
            {
                int endQuantity;
                Random r = new Random();
                endQuantity = r.Next(_addedItems[j].quantity, _addedItems[j].maxQuantity);
                for(int i = 0; i < endQuantity; i++) {
                    inventory.AddItem(_addedItems[j].item);
                }
                Debug.Log("!=");
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
                for (int j = 0; j < item.quantity ; j++)
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


        for (int j = 0; j < list.baseQuantity; j++)
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
