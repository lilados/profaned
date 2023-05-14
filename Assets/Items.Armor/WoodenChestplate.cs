using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Equip/Armor/WoodenChest")]
public class WoodenChestplate : Chest
{
    public override void Equip(Character c)
    {
        c.player.GetComponent<PlayerHealth>().baseHealth += 4;
        c.player.GetComponent<PlayerHealth>().baseDef += 2;
    }

    public override void UnEquip(Character c)
    {
        c.player.GetComponent<PlayerHealth>().baseHealth -= 4;
        c.player.GetComponent<PlayerHealth>().baseDef -= 2;
    }
}
