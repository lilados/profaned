using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BaseItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] protected Image image;
	[SerializeField] protected TextMeshProUGUI amountText;

	public event Action<BaseItemSlot> OnPointerEnterEvent;
	public event Action<BaseItemSlot> OnPointerExitEvent;
	public event Action<BaseItemSlot> OnRightClickEvent;

	protected bool isPointerOver;

	protected Color normalColor = Color.white;
	protected Color disabledColor = new Color(1, 1, 1, 0);

	protected Item _item;
	public Item Item {
		get { return _item; }
		set {
			_item = value;
			if (_item == null && Amount != 0) Amount = 0;

			if (_item == null) {
				image.sprite = null;
				image.color = disabledColor;
			} else {
				image.sprite = _item.Icon;
				image.color = normalColor;
			}

			if (isPointerOver)
			{
				OnPointerExit(null);
				OnPointerEnter(null);
			}
		}
	}

	private int _amount;
	public int Amount {
		get { return _amount; }
		set {
			_amount = value;
			if (_amount < 0) _amount = 0;
			if (_amount == 0 && Item != null) Item = null;

			if (amountText != null)
			{
				amountText.enabled = _item != null && _amount > 1;
				if (amountText.enabled) {
					amountText.text = _amount.ToString();
				}
			}
		}
	}

	private void Update()
	{
		if (_item != null)
		{
			if (_item.animator != null)
			{
				gameObject.GetComponent<Animator>().runtimeAnimatorController = Item.animator;
			}
			else
			{
				gameObject.GetComponent<Animator>().runtimeAnimatorController = null;
			}
		}
	}

	public virtual bool CanAddStack(Item item, int amount = 1)
	{
		return Item != null && Item.ID == item.ID;
	}

	public virtual bool CanReceiveItem(Item item)
	{
		return false;
	}

	protected virtual void OnValidate()
	{
		if (image == null)
			image = GetComponent<Image>();

		if (amountText == null)
			amountText = GetComponentInChildren<TextMeshProUGUI>();

		Item = _item;
		Amount = _amount;
		if (_item != null)
		{
			if (_item.animator != null)
			{
				gameObject.GetComponent<Animator>().runtimeAnimatorController = Item.animator;
			}
			else
			{
				gameObject.GetComponent<Animator>().runtimeAnimatorController = null;
			}
		}
		
		
	}

	protected virtual void OnDisable()
	{
		if (isPointerOver) {
			OnPointerExit(null);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
		{
			if (OnRightClickEvent != null)
				OnRightClickEvent(this);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		isPointerOver = true;

		if (OnPointerEnterEvent != null)
			OnPointerEnterEvent(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isPointerOver = false;

		if (OnPointerExitEvent != null)
			OnPointerExitEvent(this);
	}
}