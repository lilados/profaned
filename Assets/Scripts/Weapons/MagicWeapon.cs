using Projectiles;
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
    public GameObject mage;
    public Projectile magicProjectile;

    public override void SetDefaults()
    {
        base.SetDefaults();
        mage = Resources.Load<GameObject>("Mage");
        magicProjectile = CreateInstance<AquaStaffProj>();
    }

    public virtual void WeaponEffect(GameObject object_weapon)
    {
        magicProjectile = CreateInstance<AquaStaffProj>();
        float angle = Utility.AngleTowardsMouse(object_weapon.transform.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));

        Instantiate(
            Utility.GetProjectile(mage,CreateInstance<AquaStaffProj>())
            , object_weapon.transform.position, rot);    
    }
}