using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaStaffProj : Projectile_Magic
{
    private void OnEnable()
    {
        sprite = Resources.Load<Sprite>("aquastaff_proj");
        projDamage = 22;
    }
}
