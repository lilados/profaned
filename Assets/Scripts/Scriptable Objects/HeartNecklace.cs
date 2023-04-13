using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Equip/Necklace/Heart Necklace")]
public class HeartNecklace : Necklace
{
    public override void Equip(Character c)
    {
        c.player.GetComponent<PlayerHealth>().baseHealth += 30;
    }

        

    public override void Unequip(Character c)
    {
        c.player.GetComponent<PlayerHealth>().baseHealth -= 30;
    }
}
