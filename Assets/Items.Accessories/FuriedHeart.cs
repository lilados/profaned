using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Equip/Necklace/Furied Heart")]
public class FuriedHeart : Necklace
{
    public override void Equip(Character c)
    {
        c.player.GetComponent<PlayerHealth>().baseHealth += 30;
    }

        

    public override void UnEquip(Character c)
    {
        c.player.GetComponent<PlayerHealth>().baseHealth -= 30;
    }
}
