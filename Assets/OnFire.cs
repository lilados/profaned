using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OnFire : Modifier
{
    public override void AddEffect(GameObject entity)
    {
        base.AddEffect(entity);
        entity.GetComponent<PlayerHealth>().amountHealed += 20;
    }

    public override void RemoveEffect(GameObject entity)
    {
        base.RemoveEffect(entity);
        entity.GetComponent<PlayerHealth>().amountHealed -= 20;
        
    }
}
