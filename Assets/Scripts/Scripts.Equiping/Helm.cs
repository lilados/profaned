using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helm : EquippableItem
{
    
    public Sprite sprite;

    public virtual bool IsSetBonus(Character c)
    {
        
        return true;
    }
}
