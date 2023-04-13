using System;
using System.Collections;
using UnityEngine;
[CreateAssetMenu(menuName = "Entity/Proj/Magic")]
public class Projectile_Magic : Projectile
{
    public Sprite sprite;
    public int damage;
    public float velocity;

    public GameObject prefab;
    [HideInInspector] public Rigidbody2D rb;
    
    public virtual void OnHit(GameObject player, GameObject enemy, GameObject proj)
    {
        
        if (enemy.CompareTag("Enemy"))
        {
            enemy.GetComponent<HealthManager>().TakeDamage(damage);
        }
        Destroy(proj);
        Debug.Log("tak");
    }
}
