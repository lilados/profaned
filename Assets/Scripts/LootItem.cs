using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LootItem : ScriptableObject
{
    public Item item;
    public int amount;
    public float dropChance;
}
