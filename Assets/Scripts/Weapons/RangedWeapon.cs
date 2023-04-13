using UnityEngine;
using Weapons.Damage;

namespace Weapons
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapons/Ranged")]

    public class RangedWeapon : Weapon
    {
        [Header("Stats")]
        public int damage;
        public int bowPower;
        public float bowSpeed;
        public float bowMaxCharge;
        [Header("Misc")]
        public Projectile_Ranged ammo;
        public GameObject arrowPrefab;
        
        public virtual void WeaponEffect(GameObject object_weapon)
        {

            float angle = Utility.AngleTowardsMouse(object_weapon.transform.position);
            Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));

            Instantiate(arrowPrefab, object_weapon.transform.position, rot);
        
        }
    }
}
