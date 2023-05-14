using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : ScriptableObject
{
    public string modName;
    public float modDuration, timeLeft;
    public int level, maxLevel;
    public int modId;
    


    public virtual void AddEffect(GameObject entity)
    {
        
    }

    public virtual void Effect(GameObject entity)
    {
        timeLeft -= Time.deltaTime;
    }
    
    public virtual void RemoveEffect(GameObject entity)
    {
        
    }

    public Modifier GetCopy()
    {
        return Instantiate(this);
    }

    public bool Ended()
    {
        if (timeLeft <= 0)
        {
            return true;
        }

        return false;
    }


    public bool Upgradeable()
    {
        if (level < maxLevel)
        {
            return true;
        }
        return false;
    }

}
