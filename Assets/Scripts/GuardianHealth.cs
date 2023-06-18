using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianHealth : PlayerHealth
{
    public int absorb;

    public override void TakeDamage(int amount)
    {
        Debug.Log("dzialad2a");
    }
}
