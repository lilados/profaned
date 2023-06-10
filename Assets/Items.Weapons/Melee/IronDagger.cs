using UnityEngine;

namespace Items.Weapons.Melee
{
    [CreateAssetMenu(fileName = "Iron Dagger", menuName = "Items/Weapons/Melee/Iron Dagger")]
    public class IronDagger : MeleeWeapon
    {
        public override void WeaponEffect(GameObject sender, GameObject other)
        {
            base.WeaponEffect(sender, other);
        }
    }
}
