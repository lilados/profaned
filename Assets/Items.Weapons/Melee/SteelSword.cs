using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using modifiers;
[CreateAssetMenu]
public class SteelSword : MeleeWeapon
{
    
    public override void WeaponEffect(GameObject sender, GameObject other)
    {
        base.WeaponEffect(sender,other);
        MeleeAttack meleeAttack = sender.GetComponent<MeleeAttack>();
        other.GetComponent<HealthManager>().TakeDamage(meleeAttack._weapon.damage);
        
        sender.GetComponent<ModifierManager>().AddMod(CreateInstance<OnFire>(), 10.0f, 1, true);
    }
}
