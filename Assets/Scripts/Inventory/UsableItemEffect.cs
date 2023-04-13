using UnityEngine;

[CreateAssetMenu(menuName = "Items/Usable Item Effect")]
public abstract class UsableItemEffect : ScriptableObject
{
    public abstract void ExecuteEffect(UsableItem parentItem, Character character);

    
}