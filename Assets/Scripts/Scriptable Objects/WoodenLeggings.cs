using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Equip/Armor/WoodenLegs")]
public class WoodenLeggings : Leggings
{
    public override void Equip(Character c)
    {
        c.player.GetComponent<PlayerHealth>().baseHealth += 3;
        c.player.GetComponent<PlayerHealth>().baseDef += 2;
    }

    public override void Unequip(Character c)
    {
        c.player.GetComponent<PlayerHealth>().baseHealth -= 3;
        c.player.GetComponent<PlayerHealth>().baseDef -= 2;
    }
}