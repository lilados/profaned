using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Usable Item")]
public class UsableItem : Item
{
    public bool IsConsumable;


    public virtual void Use(Character character)
    {
        
    }

    public override string GetItemType()
    {
        return IsConsumable ? "Consumable" : "Usable";
    }
}