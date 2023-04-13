using UnityEngine;
using Weapons.Damage;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Items/Weapons/Melee")]

public class MeleeWeapon : Weapon
{
    public int damage;
    public float radius;
    public float attackSpeed;

    public RuntimeAnimatorController animator;

    public virtual void WeaponEffect(GameObject sender, GameObject other)
    {
        
    }
}