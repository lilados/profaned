using System;
using UnityEngine;
using Weapons.Damage;

namespace Weapons
{
    
    public class RangedWeapon : Weapon
    {
        [Header("Stats")]
        public int damage;
        public int bowPower;
        public float bowSpeed;
        public float bowMaxCharge;
        [HideInInspector] public GameObject ranger;
        public Projectile projectile;

        

        public override void SetDefaults()
        {
            ranger = GameObject.Find("Ranger");
            damage = 33;
            bowPower = 3;
            bowSpeed = 5;
            bowMaxCharge = 6;
            projectile = CreateInstance<Projectile>();
        }
        
        public virtual void WeaponEffect(GameObject objectWeapon)
        {
            float angle = Utility.AngleTowardsMouse(objectWeapon.transform.position);
            Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));

            Instantiate(Utility.GetProjectile(ranger, CreateInstance<Projectile>())
                , objectWeapon.transform.position, rot);
        }
    }
}
