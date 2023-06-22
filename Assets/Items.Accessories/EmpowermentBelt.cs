using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpowermentBelt : Torso
{
    private void OnEnable()
    {
        rarity = 3;
        Icon = Resources.Load<Sprite>("pib belt");
        ItemName = "Empowering Belt";
        EquipmentType = EquipmentType.Torso;
    }

    public override void Equip(Character c)
    {
        base.Equip(c);
        if (c.player.name == "Melee")
        {
            c.player.GetComponent<MeleeAttack>().meleeSpeedMult += 0.3f;
            c.player.GetComponent<MeleeAttack>().meleeDamageMult += 0.6f;
        }
    }

    public override void UnEquip(Character c)
    {
        base.UnEquip(c);
        if (c.player.name == "Melee")
        {
            c.player.GetComponent<MeleeAttack>().meleeSpeedMult -= 0.3f;
            c.player.GetComponent<MeleeAttack>().meleeDamageMult -= 0.6f;
        }
    }
}
