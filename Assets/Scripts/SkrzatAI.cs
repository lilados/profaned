using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Projectiles;

public class SkrzatAI : EnemyAI
{
    
    [SerializeField] public GameObject hand;

    public UnityEvent launchProjectile;

    public override void Start()
    {
        base.Start();
        attackInterval = 2;
    }

    public void Attack()
    {
        float angle = Utility.GetAngleBetweenGameObjects(gameObject, player);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f ,angle));
        
        
        Instantiate(Utility.GetGameObjectWithProjectile(gameObject, ScriptableObject.CreateInstance<EnemySpear>()), hand.transform.GetChild(0).transform.position, rot);
    }
}
