using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Timer = System.Timers.Timer;
[CreateAssetMenu]
public class Bleeding : Modifier
{
    
    public override void AddEffect(GameObject entity)
    {
        if (entity.CompareTag("Player"))
        {
            entity.GetComponent<PlayerHealth>().regenBlocked = true;
        }
    }

    public override void Effect(GameObject entity)
    {
        base.Effect(entity);
    }

    public override void RemoveEffect(GameObject entity)
    {
        if (entity.CompareTag("Player"))
        {
            entity.GetComponent<PlayerHealth>().regenBlocked = false;
        }
    }
}
