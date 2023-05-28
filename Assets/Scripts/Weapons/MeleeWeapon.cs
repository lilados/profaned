using UnityEngine;
using Weapons.Damage;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Items/Weapons/Melee")]

public class MeleeWeapon : Weapon
{
    public int damage;
    public float radius;
    public float attackSpeed;

    public int knockForce = 20;
    public float time = 0.2f;
    public float critChance = 70f;
    public float critDmg = 1.20f;
    


    public virtual void WeaponEffect(GameObject sender, GameObject other)
    {
        float randomChance = Random.Range(0, 100);
        if (randomChance < critChance)
        {
            other.GetComponent<HealthManager>().TakeDamage((int)(critDmg * damage));
        }else
        {
            other.GetComponent<HealthManager>().TakeDamage(damage);
        }
        
        Vector2 dir = ((other.transform.position - sender.transform.position).normalized)* knockForce;
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<KnockBackController>().TakeKnockBack(dir, time);
        }
    }
}