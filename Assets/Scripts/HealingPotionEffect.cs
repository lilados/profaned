using UnityEngine;
[CreateAssetMenu(menuName = "Items/Potions/Health")]
public class HealingPotionEffect : UsableItem
{
    public int healthRestored;

    public override void Use(Character character)
    {
        character.player.GetComponent<PlayerHealth>().health += healthRestored;
    }
}
