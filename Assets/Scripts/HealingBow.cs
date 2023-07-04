using UnityEngine;
using Weapons;
[CreateAssetMenu(menuName = "Items/Weapons/Ranged/Healbow")]
public class HealingBow : RangedWeapon
{
    

    public override void WeaponEffect(GameObject object_weapon)
    {
        float angle = Utility.AngleTowardsMouse(object_weapon.transform.position);
        Quaternion rot1 = Quaternion.Euler(new Vector3(0f, 0f, angle+ 4));
        Quaternion rot2 = Quaternion.Euler(new Vector3(0f, 0f, angle- 4));

        Instantiate(Utility.GetGameObjectWithProjectile(ranger, CreateInstance<HealArrow>()), object_weapon.transform.position, rot1);
        
        Instantiate(Utility.GetGameObjectWithProjectile(ranger, CreateInstance<HealArrow>()), object_weapon.transform.position, rot2);
    }
}
