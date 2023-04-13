using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class WoodenSword : MeleeWeapon
{
    public override void WeaponEffect(GameObject sender, GameObject other)
    {
        MeleeAttack meleeAttack = sender.GetComponent<MeleeAttack>();
        other.GetComponent<HealthManager>().TakeDamage(meleeAttack._weapon.damage);
    }
}
