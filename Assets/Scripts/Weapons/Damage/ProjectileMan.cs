using System;
using System.Collections;
using System.Collections.Generic;
using Collider2DOptimization;
using Projectiles;
using UnityEngine;

public class ProjectileMan : MonoBehaviour
{
    public Projectile proj;
    public float velocity;
    public Rigidbody2D rb;
    private Sprite Spr;
    
    // Start is called before the first frame update
    
    private void Awake()
    {
        proj.SetDefaults();
        rb = gameObject.GetComponent<Rigidbody2D>();
        name = proj.projName;
        velocity = proj.projVelocity;
        gameObject.GetComponent<SpriteRenderer>().sprite = proj.projSprite;
        gameObject.AddComponent<PolygonCollider2D>();
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        proj.ProjectileBehaviour(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        proj.OnHit(proj.sender, col.gameObject, gameObject);
    }
}
