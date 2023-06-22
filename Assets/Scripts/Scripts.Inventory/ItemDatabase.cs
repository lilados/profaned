using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Items;

namespace Scripts.Inventory
{
    public class ItemDatabase : MonoBehaviour
    {
        public List<Item> allItems;

        private void Start()
        {
            ManageDB();
        }

        void ManageDB()
        {
            allItems.Clear();
            allItems.Add(ScriptableObject.CreateInstance<WoodenChestplate>());
            allItems.Add(ScriptableObject.CreateInstance<EmpowermentBelt>());
            GameObject.Find("Inventory").GetComponent<global::Inventory>().AddItem(allItems[1]);
        }
    }
}