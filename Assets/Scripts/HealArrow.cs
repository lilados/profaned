using System;
using UnityEngine;
using SOs.Modifiers;
public class HealArrow : Projectile
{
    
    public override void SetDefaults()
    {
        base.SetDefaults();
        projVelocity = 3.8f;
        knockForce = 10;
        projSprite = Resources.Load<Sprite>("healArrow");
    }

    public override void OnHit(GameObject sender, GameObject target, GameObject projPrefab)
    {
        base.OnHit(sender, target, projPrefab);
        if (sender.CompareTag("Player"))
        {
            if (target.CompareTag("Enemy"))
            {
                target.GetComponent<HealthManager>().TakeDamage(50);
            }

            if (target.CompareTag("Player"))
            {
                target.GetComponent<PlayerHealth>().health += 30;
            }
        }
    }
}
