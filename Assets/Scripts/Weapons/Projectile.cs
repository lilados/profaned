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
        public float projVelocity, knockForce;
        public GameObject sender;
        public Vector2 directionToPlayer;

        private void OnEnable()
        {
            SetDefaults();
        }

        public virtual void OnHit(GameObject sender, GameObject target, GameObject projPrefab)
        {
            directionToPlayer = (target.transform.position - sender.transform.position).normalized * knockForce;
        }

        public virtual void SetDefaults()
        {
            projVelocity = 5.1f;
            baseDamage = 40;
        }

        public virtual void ProjectileBehaviour(GameObject target)
        {
            target.GetComponent<Rigidbody2D>().velocity = projVelocity * target.transform.right;
        }
    }

