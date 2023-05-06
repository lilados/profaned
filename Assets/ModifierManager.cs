using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    private Modifier addedMod;
    private Modifier existingSimilarMod;
    [Space]
    public List<Modifier> mods;
    
    
    private void Update()
    {
        for (int i = 0; i < mods.Count; i++)
        {
            mods[i].Effect(gameObject);
            if (mods[i].Ended())
            {
                RemoveModEffects(mods[i]);
            } 
        } 
    }


    public void AddMod(Modifier mod, float dur, int stack, bool hasUpgradePotential)
    {
        addedMod = mod.GetCopy();
        addedMod.modDuration = dur;
        addedMod.timeLeft = dur;
        addedMod.level = stack;
        if (mods.Count > 0)
        {
            FindSimilarModifier(addedMod);
            if (existingSimilarMod != null)
            {
                if (addedMod.level > existingSimilarMod.level)
                {
                    RemoveModEffects(existingSimilarMod);
                    AddModEffects(addedMod);
                } 
                
                else if (addedMod.level == existingSimilarMod.level)
                {
                    if (hasUpgradePotential && addedMod.Upgradeable())
                    {
                        RemoveModEffects(existingSimilarMod);
                        ++addedMod.level;
                        AddModEffects(addedMod);
                    }
                    else
                    {
                        existingSimilarMod.timeLeft = existingSimilarMod.modDuration;
                    }
                }
                
                else if (addedMod.level < existingSimilarMod.level)
                {
                    existingSimilarMod.timeLeft = existingSimilarMod.modDuration;
                }
            }
            else
            {
                AddModEffects(addedMod);
            }
        }
        else
        {
            AddModEffects(addedMod);
        }
    }


    private void AddModEffects(Modifier mod)
    {
        mod.AddEffect(gameObject);
        mods.Add(mod);
    }

    private void RemoveModEffects(Modifier mod)
    {
        mod.RemoveEffect(gameObject);
        mods.Remove(mod);
    }

    
    private void FindSimilarModifier(Modifier checkedMod)
    {
        for (int i = 0; i < mods.Count; i++)
        {
            if (mods[i].modName == checkedMod.modName)
            {
                existingSimilarMod = mods[i];
            }
        }
    }
}


    

    
