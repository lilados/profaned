using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMan : MonoBehaviour
{
    public Projectile proj;
    public float velocity;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void OnValidate()
    {
        proj = ScriptableObject.CreateInstance<EnemySpear>();
        proj.Sett();
        rb = gameObject.GetComponent<Rigidbody2D>();
        name = proj.projName;
        velocity = proj.projVelocity;
        gameObject.GetComponent<SpriteRenderer>().sprite = proj.projSprite;

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity * Vector2.right;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            proj.OnHit(col.gameObject, gameObject);
            Destroy(gameObject);
        }
    }
}
