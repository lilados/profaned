using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Projectiles
{
    public class Star : Projectile
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            projSprite = Resources.Load<Sprite>("gwiazda");
            projName = "Star";
            knockForce = 3;
        }

        public override void OnHit(GameObject sender, GameObject target, GameObject pre)
        {
            base.OnHit(sender, target, pre);
            if (sender.CompareTag("Enemy"))
            {
                if (target.CompareTag("Player"))
                {
                    target.GetComponent<PlayerHealth>().TakeDamage(190);
                    target.GetComponent<PlayerHealth>().TakeKnockBack(directionToPlayer);
                }
                Destroy(pre);
            }
        }

       

        public override void ProjectileBehaviour(GameObject target)
        {
            base.ProjectileBehaviour(target);
            target.GetComponent<Rigidbody2D>().velocity = projVelocity * (Utility.GetClosestEnemy(
                GameObject.FindGameObjectsWithTag("Player"), target.transform
            ).transform.position - target.transform.position).normalized;

        }
    }
}