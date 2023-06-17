using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Entity/Proj/Range")]
public class Projectile_Ranged : Projectile
{
    public Sprite Sprite;
    public int projDamage, damage, knockForce = 5;
    public float velocity = 7, time = 0.2f;
    
    
    public virtual void OnHit(GameObject player, GameObject enemy, GameObject arrow)
    {
        damage = player.GetComponent<RangedAttack>().rangeDamage;
        if(enemy.CompareTag("Enemy"))
        {
            Vector2 dir = ((enemy.transform.position - player.transform.position).normalized)* knockForce;
            enemy.GetComponent<KnockBackController>().TakeKnockBack(dir, time);
            enemy.GetComponent<HealthManager>().TakeDamage(damage);
        }
        Destroy(arrow);
    }
}
