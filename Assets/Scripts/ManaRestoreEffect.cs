using UnityEngine;
[CreateAssetMenu(menuName = "Items/Potions/Mana")]
public class ManaRestoreEffect : UsableItem
{
    public int manaRestored;

    public override void Use(Character character)
    {
        character.player.GetComponent<MagicAttack>().mana += manaRestored;
    }
}