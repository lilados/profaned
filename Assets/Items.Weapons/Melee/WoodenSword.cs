using SOs.Modifiers;
using UnityEngine;

namespace Items.Weapons.Melee
{
    [CreateAssetMenu]
    public class WoodenSword : MeleeWeapon
    {
        public override void WeaponEffect(GameObject sender, GameObject other)
        {
            base.WeaponEffect(sender,other);
            MeleeAttack meleeAttack = sender.GetComponent<MeleeAttack>();
            other.GetComponent<HealthManager>().TakeDamage(meleeAttack._weapon.damage);
        
            sender.GetComponent<ModifierManager>().AddMod(CreateInstance<OnFire>(), 10.0f, 1, true);
        }
    }
}
