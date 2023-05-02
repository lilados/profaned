using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    public Modifier currentMod;
    public Modifier otherMod;
    public List<Modifier> mods;

    private void Update()
    {
        for (int i = 0; i < mods.Count; i++)
        {
            mods[i].Effect(gameObject);
            if (mods[i].Ended())
            {
                if (mods[i] == otherMod)
                {
                    otherMod = null;
                }
                RemoveMod(mods[i]);
            } } }
    

    public void AddMod(Modifier mod, float dur, int stack)
    {
        currentMod = mod;
        foreach (Modifier modBefore in mods)
        {
            if (modBefore.modName == mod.modName)
            {
                otherMod = modBefore;
            }
        }
        if (!mods.Contains(mod))
        {
            mod.modDuration = dur;
            mod.timeLeft = mod.modDuration;
            mod.level = stack;
            mods.Add(mod);
            mod.AddEffect(gameObject);
        }

        if (otherMod != null)
        {
            if (mod.level < otherMod.level)
            {
                Debug.Log("<");
                otherMod.timeLeft = otherMod.modDuration;
            }
            if (mod.level > otherMod.level)
            {
                Debug.Log(">");
            }
            if (mod.level == otherMod.level && mod.Upgradeable())
            {
                Debug.Log("=");
                UpgradeMod(mod);
            }
        }
    }

    public void RemoveMod(Modifier mod)
    {
        mod.RemoveEffect(gameObject);
        mods.Remove(mod);
    }
    
    public void UpgradeMod(Modifier mod)
    {
        RemoveMod(mod);
        AddMod(mod, mod.modDuration, mod.level + 1);
    }
}
