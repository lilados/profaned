using System;
using System.Collections;
using UnityEngine;
[CreateAssetMenu(menuName = "Entity/Proj/Magic")]
public class Projectile_Magic : Projectile
{
    public Sprite sprite;
    public int projDamage = 10, damage,  knockForce= 20;
    public float velocity= 6.0f, time = 0.2f;

    public GameObject prefab;
    [HideInInspector] public Rigidbody2D rb;
    
    public virtual void OnHit(GameObject player, GameObject enemy, GameObject proj)
    {
        damage = player.GetComponent<MagicAttack>().magicDamage;
        if (enemy.CompareTag("Enemy"))
        {
            Vector2 dir = ((enemy.transform.position - player.transform.position).normalized)* knockForce;
            enemy.GetComponent<KnockBackController>().TakeKnockBack(dir, time);
            enemy.GetComponent<HealthManager>().TakeDamage(damage);
        }
        Destroy(proj);
    }
}
