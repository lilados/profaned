using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Equip/Armor/WoodenHelmet")]
public class WoodenHelmet : Helm
{
    public Chest chest;
    public Leggings legs;
    public override void Equip(Character c)
    {
        c.player.GetComponent<PlayerHealth>().baseHealth += 3;
        c.player.GetComponent<PlayerHealth>().baseDef += 5;
    }

    public override void UnEquip(Character c)
    {
        c.player.GetComponent<PlayerHealth>().baseHealth -= 3;
        c.player.GetComponent<PlayerHealth>().baseDef -= 5;
    }

    public override bool IsSetBonus(Character c)
    {
        if (c.player.GetComponent<PlayerController>().chest == chest && c.player.GetComponent<PlayerController>().legs == legs)
            return true;
        else
            return false;
    }
}
