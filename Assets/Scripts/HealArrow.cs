using System;
using UnityEngine;
using SOs.Modifiers;
public class HealArrow : Projectile_Ranged
{
    private void OnEnable()
    {
        damage = 40;
        knockForce = 10;
        time = 0.2f;
        velocity = 6;
        Sprite = Resources.Load<Sprite>("healArrow");
    }

    public override void OnHit(GameObject player, GameObject enemy, GameObject arrow)
    {
        base.OnHit(player,enemy,arrow);
        if (enemy.CompareTag("Enemy"))
        {
            player.GetComponent<PlayerHealth>().health += 20;
            enemy.GetComponent<ModifierManager>().AddMod(CreateInstance<OnFire>(), 2f, 1, true);
        }
        
    }
}
