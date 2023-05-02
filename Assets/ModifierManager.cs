using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    public Modifier addedMod;
    public Modifier beforeMod;
    public List<Modifier> mods;

    private void Update()
    {
        for (int i = 0; i < mods.Count; i++)
        {
            mods[i].Effect(gameObject);
            if (mods[i].Ended())
            {
                RemoveMod(mods[i]);
            } } }
    

    public void AddMod(Modifier mod0, float dur, int stack, bool upgradePotential)
    {
        Modifier mod = mod0.GetCopy();
        if (mods.Count > 0)
        {
            if (ListContainsItem(mod))
            {
                if (mods[GetModID(mod)].Upgradeable() && upgradePotential)
                {
                    UpgradeMod(mod);
                }
                else
                {
                    
                }
            }
            

            
        }
        else
        {
            AddModEffects(mod, dur, stack);
        }
    }


    private void AddModEffects(Modifier mod, float dur, int stack)
    {
        mod.modDuration = dur;
        mod.timeLeft = mod.modDuration;
        mod.level = stack;
        mod.AddEffect(gameObject);
        mods.Add(mod);
    }
    private void RemoveMod(Modifier mod)
    {
        mod.RemoveEffect(gameObject);
        mods.Remove(mod);
    }
    
    private void UpgradeMod(Modifier mod)
    {
        RemoveMod(mod);
        AddMod(mod, mod.modDuration, mod.level + 1, true);
    }


    private bool ListContainsItem(Modifier mod2)
    {
        for (int i = 0; i < mods.Count ; i++)
        {
            if (mods[i].modName == mod2.modName)
            {
                beforeMod = mods[i];
                return true;
            }
        }

        return false;

    }

    private int GetModID(Modifier mod5)
    {
        for (int i = 0; i < mods.Count; i++)
        {
            if (mods[i] == mod5)
            {
                return i;
            }
        }

        return 0;
    }
}
