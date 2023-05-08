using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class WoodenSword : MeleeWeapon
{
    public Modifier mod;
    public override void WeaponEffect(GameObject sender, GameObject other)
    {
        base.WeaponEffect(sender,other);
        MeleeAttack meleeAttack = sender.GetComponent<MeleeAttack>();
        other.GetComponent<HealthManager>().TakeDamage(meleeAttack._weapon.damage);
        
        sender.GetComponent<ModifierManager>().AddMod(mod, 10.0f, 1, true);
    }
}
