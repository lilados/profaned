using UnityEngine;
using UnityEngine.UI;
using Weapons;
using Weapons.Damage;

public class Character : MonoBehaviour
{


	[Header("Public")]
	public Inventory Inventory;
	public EquipmentPanel EquipmentPanel;

	[Header("Serialize Field")]
	[SerializeField] CraftingWindow craftingWindow;
	[SerializeField] ItemTooltip itemTooltip;
	[SerializeField] Image draggableItem;

	public GameObject player;
	public int playerSelected;
	public GameObject[] players;

	public bool setBonusActive;
	
	private BaseItemSlot dragItemSlot;
	
	
	 

	private void OnValidate()
	{
		if (itemTooltip == null)
			itemTooltip = FindObjectOfType<ItemTooltip>();
	}

	private void Start()
	{

		// Setup Events:
		// Right Click
		Inventory.OnRightClickEvent += InventoryRightClick;
		EquipmentPanel.OnRightClickEvent += EquipmentPanelRightClick;
		// Pointer Enter
		Inventory.OnPointerEnterEvent += ShowTooltip;
		EquipmentPanel.OnPointerEnterEvent += ShowTooltip;
		craftingWindow.OnPointerEnterEvent += ShowTooltip;
		// Pointer Exit
		Inventory.OnPointerExitEvent += HideTooltip;
		EquipmentPanel.OnPointerExitEvent += HideTooltip;
		craftingWindow.OnPointerExitEvent += HideTooltip;
		// Begin Drag
		Inventory.OnBeginDragEvent += BeginDrag;
		EquipmentPanel.OnBeginDragEvent += BeginDrag;
		// End Drag
		Inventory.OnEndDragEvent += EndDrag;
		EquipmentPanel.OnEndDragEvent += EndDrag;
		// Drag
		Inventory.OnDragEvent += Drag;
		EquipmentPanel.OnDragEvent += Drag;
		// Drop
		Inventory.OnDropEvent += Drop;
		EquipmentPanel.OnDropEvent += Drop;

		playerSelected = PlayerPrefs.GetInt("selectedCharacter");

		player = players[playerSelected];
	}

	private void InventoryRightClick(BaseItemSlot itemSlot)
	{
		GameObject melee = GameObject.Find("Melee");
		GameObject ranger = GameObject.Find("Ranger");
		GameObject mage = GameObject.Find("Mage");
		if (itemSlot.Item is MeleeWeapon && melee != null) 
		{
			melee.GetComponent<MeleeAttack>()._weapon = (MeleeWeapon)itemSlot.Item;
			Equip((EquippableItem)itemSlot.Item);
		} 
		if (itemSlot.Item is RangedWeapon && ranger != null)
		{
			ranger.GetComponent<RangedAttack>()._weapon = (RangedWeapon)itemSlot.Item;
			Equip((EquippableItem)itemSlot.Item);
		} 
		if (itemSlot.Item is MagicWeapon && mage != null)
		{
			mage.GetComponent<MagicAttack>().weapon = (MagicWeapon)itemSlot.Item;
			Equip((EquippableItem)itemSlot.Item);
		}
		
		if(itemSlot.Item is Helm)
		{
			player.GetComponent<PlayerController>().helmet = (Helm)itemSlot.Item;
			player.transform.Find("Head").GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerController>().helmet.sprite;


		}
		if(itemSlot.Item is Chest)
		{
			player.GetComponent<PlayerController>().chest = (Chest)itemSlot.Item;
			player.transform.Find("Chest").GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerController>().chest.sprite;
		}
		if(itemSlot.Item is Leggings)
		{
			player.GetComponent<PlayerController>().legs = (Leggings)itemSlot.Item;
			player.transform.Find("Legs").GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerController>().legs.sprite;
		}
		
		
		if(itemSlot.Item is Necklace)
		{
			player.GetComponent<PlayerController>().neck = (Necklace)itemSlot.Item;
		}
		if(itemSlot.Item is Feet)
		{
			player.GetComponent<PlayerController>().feetWear = (Feet)itemSlot.Item;
		}
		if(itemSlot.Item is Hands)
		{
			player.GetComponent<PlayerController>().hands = (Hands)itemSlot.Item;
		}
		if(itemSlot.Item is Arm)
		{
			player.GetComponent<PlayerController>().arm = (Arm)itemSlot.Item;
		}
		if(itemSlot.Item is Torso)
		{
			player.GetComponent<PlayerController>().torso = (Torso)itemSlot.Item;
		}
		if(itemSlot.Item is SpecialAccessory)
		{
			player.GetComponent<PlayerController>().acc = (SpecialAccessory)itemSlot.Item;
		}
		
		if (itemSlot.Item is EquippableItem and not Weapon)
		{
			Equip((EquippableItem)itemSlot.Item);
		}
		
		
		else if (itemSlot.Item is UsableItem)
		{
			UsableItem usableItem = (UsableItem)itemSlot.Item;
			usableItem.Use(this);

			if (usableItem.IsConsumable)
			{
				itemSlot.Amount--;
				usableItem.Destroy();
			}
		}
		
	}

	private void EquipmentPanelRightClick(BaseItemSlot itemSlot)
	{
		GameObject melee = GameObject.Find("Melee");
		GameObject ranger = GameObject.Find("Ranger");
		GameObject mage = GameObject.Find("Mage");

		if (itemSlot.Item is MeleeWeapon)
		{
			melee.GetComponent<MeleeAttack>()._weapon = null;
		}

		if (itemSlot.Item is RangedWeapon)
		{
			ranger.GetComponent<RangedAttack>()._weapon = null;
		}

		if (itemSlot.Item is MagicWeapon)
		{
			mage.GetComponent<MagicAttack>().weapon = null;
		}
		if(itemSlot.Item is Helm)
		{
			player.GetComponent<PlayerController>().helmet = null;
			player.transform.Find("Head").GetComponent<SpriteRenderer>().sprite = null;		
		}
		if(itemSlot.Item is Chest)
		{
			player.GetComponent<PlayerController>().chest = null;
			player.transform.Find("Chest").GetComponent<SpriteRenderer>().sprite = null;	
		}
		if(itemSlot.Item is Leggings)
		{
			player.GetComponent<PlayerController>().legs = null;
			player.transform.Find("Legs").GetComponent<SpriteRenderer>().sprite = null;	
		}
		
		
		if(itemSlot.Item is Necklace)
		{
			
			player.GetComponent<PlayerController>().neck = null;
		}
		if(itemSlot.Item is Feet)
		{
			
			player.GetComponent<PlayerController>().feetWear = null;
		}
		if(itemSlot.Item is Hands)
		{
			
			player.GetComponent<PlayerController>().hands = null;
		}
		if(itemSlot.Item is Arm)
		{
			
			player.GetComponent<PlayerController>().arm = null;
		}
		if(itemSlot.Item is Torso)
		{
			
			player.GetComponent<PlayerController>().torso = null;
		}
		if(itemSlot.Item is SpecialAccessory)
		{
			
			player.GetComponent<PlayerController>().acc = null;
		}
		
		if (itemSlot.Item is EquippableItem)
		{
			Unequip((EquippableItem)itemSlot.Item);
		}
	}

	private void ShowTooltip(BaseItemSlot itemSlot)
	{
		if (itemSlot.Item != null)
		{
			itemTooltip.ShowTooltip(itemSlot.Item);
		}
	}

	private void HideTooltip(BaseItemSlot itemSlot)
	{
		if (itemTooltip.gameObject.activeSelf)
		{
			itemTooltip.HideTooltip();
		}
	}

	private void BeginDrag(BaseItemSlot itemSlot)
	{
		if (itemSlot.Item != null)
		{
			dragItemSlot = itemSlot;
			draggableItem.sprite = itemSlot.Item.Icon;
			draggableItem.transform.position = Input.mousePosition;
			draggableItem.gameObject.SetActive(true);
		}
	}

	private void Drag(BaseItemSlot itemSlot)
	{
		draggableItem.transform.position = Input.mousePosition;
	}
	
	private void EndDrag(BaseItemSlot itemSlot)
	{
		
		dragItemSlot = null;
		draggableItem.gameObject.SetActive(false);
	}

	private void Drop(BaseItemSlot dropItemSlot)
	{
		if (dragItemSlot == null) return;

		if (dropItemSlot.CanAddStack(dragItemSlot.Item))
		{
			AddStacks(dropItemSlot);
		}
		else if (dropItemSlot.CanReceiveItem(dragItemSlot.Item) && dragItemSlot.CanReceiveItem(dropItemSlot.Item))
		{
			SwapItems(dropItemSlot);
		}
	}

	private void AddStacks(BaseItemSlot dropItemSlot)
	{
		int numAddableStacks = dropItemSlot.Item.MaximumStacks - dropItemSlot.Amount;
		int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

		dropItemSlot.Amount += stacksToAdd;
		dragItemSlot.Amount -= stacksToAdd;
	}

	private void SwapItems(BaseItemSlot dropItemSlot)
	{
		EquippableItem dragEquipItem = dragItemSlot.Item as EquippableItem;
		EquippableItem dropEquipItem = dropItemSlot.Item as EquippableItem;

		if (dropItemSlot is EquipmentSlot)
		{
			if (dragEquipItem != null)
			{
				dragEquipItem.Equip(this);

				if (dragEquipItem is Helm)
				{
					player.GetComponent<PlayerController>().helmet = (Helm)dragEquipItem;
					player.transform.Find("Head").GetComponent<SpriteRenderer>().sprite =
						player.GetComponent<PlayerController>().helmet.sprite;
				}

				if (dragEquipItem is Chest)
				{
					player.GetComponent<PlayerController>().chest = (Chest)dragEquipItem; 
					player.transform.Find("Chest").GetComponent<SpriteRenderer>().sprite = 
						player.GetComponent<PlayerController>().chest.sprite;
				}

				if (dragEquipItem is Leggings)
				{
					player.GetComponent<PlayerController>().legs = (Leggings)dragEquipItem; 
					player.transform.Find("Legs").GetComponent<SpriteRenderer>().sprite = 
						player.GetComponent<PlayerController>().legs.sprite;
				}

				if (dragEquipItem is Arm)
				{
					player.GetComponent<PlayerController>().arm = (Arm)dragEquipItem;
				}

				if (dragEquipItem is Torso)
				{
					player.GetComponent<PlayerController>().torso = (Torso)dragEquipItem;
				}

				if (dragEquipItem is Necklace)
				{
					player.GetComponent<PlayerController>().neck = (Necklace)dragEquipItem;
				}

				if (dragEquipItem is Feet)
				{
					player.GetComponent<PlayerController>().feetWear = (Feet)dragEquipItem;
				}

				if (dragEquipItem is Hands)
				{
					player.GetComponent<PlayerController>().hands = (Hands)dragEquipItem;
				}

				if (dragEquipItem is SpecialAccessory)
				{
					player.GetComponent<PlayerController>().acc = (SpecialAccessory)dragEquipItem;
				}

				if (dragEquipItem is MeleeWeapon)
				{
					player.GetComponent<MeleeAttack>()._weapon = (MeleeWeapon)dragEquipItem;
				}
				if (dragEquipItem is RangedWeapon)
				{
					player.GetComponent<RangedAttack>()._weapon = (RangedWeapon)dragEquipItem;
				}
				if (dragEquipItem is MagicWeapon)
				{
					player.GetComponent<MagicAttack>().weapon = (MagicWeapon)dragEquipItem;
				}
			}
			if (dropEquipItem != null) dropEquipItem.UnEquip(this);
		}
		if (dragItemSlot is EquipmentSlot)
		{
			if (dragEquipItem != null)
			{
				dragEquipItem.UnEquip(this);
				
				if (dragEquipItem is Helm) player.GetComponent<PlayerController>().helmet = null; player.transform.Find("Head").GetComponent<SpriteRenderer>().sprite = null;	
				if (dragEquipItem is Chest) player.GetComponent<PlayerController>().chest = null; player.transform.Find("Chest").GetComponent<SpriteRenderer>().sprite = null;	
				if (dragEquipItem is Leggings) player.GetComponent<PlayerController>().legs = null ;player.transform.Find("Legs").GetComponent<SpriteRenderer>().sprite = null;	
				
				if (dragEquipItem is Arm) player.GetComponent<PlayerController>().arm = null;
				if (dragEquipItem is Torso) player.GetComponent<PlayerController>().torso = null;
				if (dragEquipItem is Necklace) player.GetComponent<PlayerController>().neck = null;
				if (dragEquipItem is Feet) player.GetComponent<PlayerController>().feetWear = null;
				if (dragEquipItem is Hands) player.GetComponent<PlayerController>().hands = null;
				if (dragEquipItem is SpecialAccessory) player.GetComponent<PlayerController>().acc = null;
				
				if (dragEquipItem is MeleeWeapon) player.GetComponent<MeleeAttack>()._weapon = null;
				if (dragEquipItem is RangedWeapon) player.GetComponent<RangedAttack>()._weapon = null;
				if (dragEquipItem is MagicWeapon) player.GetComponent<MagicAttack>().weapon = null;
			}
			if (dropEquipItem != null) dropEquipItem.Equip(this);
		}

		Item draggedItem = dragItemSlot.Item;
		int draggedItemAmount = dragItemSlot.Amount;

		dragItemSlot.Item = dropItemSlot.Item;
		dragItemSlot.Amount = dropItemSlot.Amount;

		dropItemSlot.Item = draggedItem;
		dropItemSlot.Amount = draggedItemAmount;
	}

	private void DropItemOutsideUI()
	{
		if (dragItemSlot == null) return;

		BaseItemSlot slot = dragItemSlot;
	}

	private void DestroyItemInSlot(BaseItemSlot itemSlot)
	{
		// If the item is equiped, unequip first
		if (itemSlot is EquipmentSlot)
		{
			EquippableItem equippableItem = (EquippableItem)itemSlot.Item;
			equippableItem.UnEquip(this);
		}

		itemSlot.Item.Destroy();
		itemSlot.Item = null;
	}

	public void Equip(EquippableItem item)
	{
		
		if (Inventory.RemoveItem(item))
		{
			EquippableItem previousItem;
			if (EquipmentPanel.AddItem(item, out previousItem))
			{
				if (previousItem != null)
				{
					Inventory.AddItem(previousItem);
					previousItem.UnEquip(this);
				}
				item.Equip(this);
			}
			else
			{
				Inventory.AddItem(item);
			}
		}
	}

	public void Unequip(EquippableItem item)
	{
		if (Inventory.CanAddItem(item) && EquipmentPanel.RemoveItem(item))
		{
			item.UnEquip(this);
			Inventory.AddItem(item);
		}
	}

	private ItemContainer openItemContainer;

	private void TransferToItemContainer(BaseItemSlot itemSlot)
	{
		Item item = itemSlot.Item;
		if (item != null && openItemContainer.CanAddItem(item))
		{
			Inventory.RemoveItem(item);
			openItemContainer.AddItem(item);
		}
	}

	private void TransferToInventory(BaseItemSlot itemSlot)
	{
		Item item = itemSlot.Item;
		if (item != null && Inventory.CanAddItem(item))
		{
			openItemContainer.RemoveItem(item);
			Inventory.AddItem(item);
		}
	}

	public void OpenItemContainer(ItemContainer itemContainer)
	{
		openItemContainer = itemContainer;

		Inventory.OnRightClickEvent -= InventoryRightClick;
		Inventory.OnRightClickEvent += TransferToItemContainer;

		itemContainer.OnRightClickEvent += TransferToInventory;

		itemContainer.OnPointerEnterEvent += ShowTooltip;
		itemContainer.OnPointerExitEvent += HideTooltip;
		itemContainer.OnBeginDragEvent += BeginDrag;
		itemContainer.OnEndDragEvent += EndDrag;
		itemContainer.OnDragEvent += Drag;
		itemContainer.OnDropEvent += Drop;
	}

	public void CloseItemContainer(ItemContainer itemContainer)
	{
		openItemContainer = null;

		Inventory.OnRightClickEvent += InventoryRightClick;
		Inventory.OnRightClickEvent -= TransferToItemContainer;

		itemContainer.OnRightClickEvent -= TransferToInventory;

		itemContainer.OnPointerEnterEvent -= ShowTooltip;
		itemContainer.OnPointerExitEvent -= HideTooltip;
		itemContainer.OnBeginDragEvent -= BeginDrag;
		itemContainer.OnEndDragEvent -= EndDrag;
		itemContainer.OnDragEvent -= Drag;
		itemContainer.OnDropEvent -= Drop;
	}
}
