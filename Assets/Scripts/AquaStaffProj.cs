using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaStaffProj : Projectile
{
    private void OnEnable()
    {
        projSprite = Resources.Load<Sprite>("aquastaff_proj");
        baseDamage = 22;
    }
}
