using UnityEngine;
using Weapons.Damage;

[CreateAssetMenu(fileName = "New Magic Weapon", menuName = "Items/Weapons/Magic")]

public class MagicWeapon : Weapon
{
    [Header("Stats")]
    public int damage;
    public int manaCost;
    public float castSpeed;
    [Space]
    [Header("Misc")]
    public Projectile_Magic magic;
    public GameObject prefab;
    
    public virtual void WeaponEffect(GameObject object_weapon)
    {
        float angle = Utility.AngleTowardsMouse(object_weapon.transform.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));

        Instantiate(prefab, object_weapon.transform.position, rot);    
    }
}