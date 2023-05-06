using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OnFire : Modifier
{
    public int playerHealthBefore;
    public override void AddEffect(GameObject entity)
    {
        playerHealthBefore = entity.GetComponent<PlayerHealth>().amountHealed;
        base.AddEffect(entity);
        switch (level)
        {
            case 1: entity.GetComponent<PlayerHealth>().amountHealed += 20;
                break;
                
            case 2:entity.GetComponent<PlayerHealth>().amountHealed += 40;
                break;
        }
            
        
    }

    public override void RemoveEffect(GameObject entity)
    {
        base.RemoveEffect(entity);
        entity.GetComponent<PlayerHealth>().amountHealed = playerHealthBefore;
    }
}
