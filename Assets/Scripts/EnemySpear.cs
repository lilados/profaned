using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpear : Projectile
{
    public override void Sett()
    {
        projSprite = Resources.Load<Sprite>("wlocznia");
        projName = "Spear";
        projVelocity = 0.9f;
        baseDamage = 40;
    }

    public override void OnHit(GameObject player, GameObject enemy)
    {
        base.OnHit(player, enemy);
        player.GetComponent<PlayerHealth>().health -= baseDamage;
        
    }
}
