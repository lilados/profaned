using System;
using UnityEngine;

namespace Items.Weapons.Melee
{
    [CreateAssetMenu(fileName = "Iron Dagger", menuName = "Items/Weapons/Melee/Iron Dagger")]
    public class IronDagger : MeleeWeapon
    {
        private void OnEnable()
        {
            attackSpeed = 20;
            
        }

        public override void WeaponEffect(GameObject sender, GameObject other)
        {
            base.WeaponEffect(sender, other);
        }
    }
}
