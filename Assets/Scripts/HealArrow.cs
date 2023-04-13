using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class HealArrow : Projectile_Ranged
{
    
    public override void OnHit(GameObject player, GameObject enemy, GameObject arrow)
    {
        base.OnHit(player,enemy,arrow);
        if (enemy.CompareTag("Enemy"))
        {
            player.GetComponent<PlayerHealth>().health += 20;
        }
    }
}
