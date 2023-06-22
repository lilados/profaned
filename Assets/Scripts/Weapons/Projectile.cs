using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ScriptableObject
{
    protected int ProjectileId;
    public int baseDamage;
    public string projName;
    public Sprite projSprite;
    public float projVelocity;
    
    
    public virtual void OnHit(GameObject player, GameObject enemy)
    {
        
    }

    public virtual void Sett()
    {
        
    }
}
