using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Entity/Proj/Range")]
public class Projectile_Ranged : Projectile
{
    public Sprite Sprite;
    public int damage;
    public float velocity;
    
    public GameObject prefab;
    
    public virtual void OnHit(GameObject player, GameObject enemy, GameObject arrow)
    {
        if(enemy.CompareTag("Enemy"))
        {
            enemy.GetComponent<HealthManager>().TakeDamage(damage);
        }
        Destroy(arrow);
    }
}
