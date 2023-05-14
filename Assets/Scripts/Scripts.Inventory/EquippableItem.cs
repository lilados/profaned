using System.ComponentModel;
using UnityEngine;
using Weapons;

public enum EquipmentType
{
	Helmet,
	Chest,
	Leggings,
	Hands,
	Accessory,
	Arm,
	Torso,
	Neck,
	Feet,
	[Description("Melee Weapon")]MeleeWeapon,
	[Description("Ranged Weapon")]RangedWeapon,
	[Description("Magic Weapon")]MagicWeapon
}

[CreateAssetMenu(menuName = "Items/Equippable Item")]
public class EquippableItem : Item
{
	
	[HideInInspector]public EquipmentType EquipmentType;

	protected override void OnValidate()
	{
		if (this is MeleeWeapon)
		{
			EquipmentType = EquipmentType.MeleeWeapon;
		}
		if (this is RangedWeapon)
		{
			EquipmentType = EquipmentType.RangedWeapon;
		}
		if (this is MagicWeapon)
		{
			EquipmentType = EquipmentType.MagicWeapon;
		}
		
		if (this is Helm)
		{
			EquipmentType = EquipmentType.Helmet;
		}
		if (this is Chest)
		{
			EquipmentType = EquipmentType.Chest;
		}
		if (this is Leggings)
		{
			EquipmentType = EquipmentType.Leggings;
		}
		
		if (this is SpecialAccessory)
		{
			EquipmentType = EquipmentType.Accessory;
		}
		if (this is Necklace)
		{
			EquipmentType = EquipmentType.Neck;
		}
		if (this is Torso)
		{
			EquipmentType = EquipmentType.Torso;
		}
		if (this is Arm)
		{
			EquipmentType = EquipmentType.Arm;
		}
		if (this is Feet)
		{
			EquipmentType = EquipmentType.Feet;
		}
		if (this is Hands)
		{
			EquipmentType = EquipmentType.Hands;
		}
		
	}

	public override Item GetCopy()
	{
		return Instantiate(this);
	}

	public override void Destroy()
	{
		Destroy(this);
	}

	public virtual void Equip(Character c)
	{
		
	}

	public virtual void Equipped(Character c)
	{
		
	}
	public virtual void UnEquip(Character c)
	{
		
	}

	public override string GetItemType()
	{
		return EquipmentType.ToString();
	}

	public override string GetDescription()
	{
		sb.Length = 0;
		
		return sb.ToString();
	}

	
	
}