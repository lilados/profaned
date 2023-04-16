using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Entity/Proj/Range")]
public class Projectile_Ranged : Projectile
{
    public Sprite Sprite;
    public int damage = 20, knockForce = 5;
    public float velocity = 7, time = 0.2f;
    
    public GameObject prefab;
    
    public virtual void OnHit(GameObject player, GameObject enemy, GameObject arrow)
    {
        
        if(enemy.CompareTag("Enemy"))
        {
            Vector2 dir = ((enemy.transform.position - player.transform.position).normalized)* knockForce;
            enemy.GetComponent<Enemy>().TakeKnockback(dir, time);
            enemy.GetComponent<HealthManager>().TakeDamage(damage);
        }
        Destroy(arrow);
    }
}
