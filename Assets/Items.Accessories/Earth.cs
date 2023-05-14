using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Items.Accessories
{
    [CreateAssetMenu(menuName = "Items/Equip/Feet/Earth")]
    public class Earth : Feet
    {
        public override void Equip(Character c)
        {
            base.Equip(c);
            c.player.GetComponent<Movement>().baseSpeed += 2;
        }

        public override void UnEquip(Character c)
        {
            base.UnEquip(c);
            c.player.GetComponent<Movement>().baseSpeed -= 2;
        }
    }
}

