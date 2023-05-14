using System;
using System.Collections;
using UnityEngine;
[CreateAssetMenu(menuName = "Entity/Proj/Magic")]
public class Projectile_Magic : Projectile
{
    public Sprite sprite;
    public int damage = 10, knockForce= 20;
    public float velocity= 6.0f, time = 0.2f;

    public GameObject prefab;
    [HideInInspector] public Rigidbody2D rb;
    
    public virtual void OnHit(GameObject player, GameObject enemy, GameObject proj)
    {
        Vector2 dir = ((enemy.transform.position - player.transform.position).normalized)* knockForce;
        enemy.GetComponent<KnockBackController>().TakeKnockBack(dir, time);
        if (enemy.CompareTag("Enemy"))
        {
            enemy.GetComponent<HealthManager>().TakeDamage(damage);
        }
        Destroy(proj);
    }
}
