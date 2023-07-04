using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles
{

    public class EnemySpear : Projectile
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            projSprite = Resources.Load<Sprite>("wlocznia");
            projName = "Spear";
        }

        public override void OnHit(GameObject sender, GameObject target, GameObject pre)
        {
            base.OnHit(sender, target, pre);
            if (sender.CompareTag("Enemy"))
            {
                if (target.CompareTag("Player"))
                {
                    target.GetComponent<PlayerHealth>().TakeDamage(190);
                }
                Destroy(pre);
            }

        }

    }
}
